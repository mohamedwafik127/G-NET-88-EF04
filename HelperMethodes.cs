using NationalBank.Model;

namespace NationalBank
{
    public static class HelperMethodes
    {
        public static int ReadInt(string label)
        {
            while (true)
            {
                Console.Write($"{label.PadRight(15)}: ");

                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;

                Console.WriteLine("  Invalid number, please try again.");
            }
        }

        public static string ReadRequired(string label, int maxLength)
        {
            while (true)
            {
                Console.Write($"{label.PadRight(15)}: ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("  This field cannot be empty. Try again.");
                    continue;
                }
                if (input.Length > maxLength)
                {
                    Console.WriteLine($"  Too long (max {maxLength} characters). Try again.");
                    continue;
                }
                return input;
            }
        }

        public static string ReadDigits(string label, int maxLength)
        {
            while (true)
            {
                string input = ReadRequired(label, maxLength);

                if (input.All(char.IsDigit))
                    return input;

                Console.WriteLine("  Digits only, please. Try again.");
            }
        }

        public static string ReadEmail()
        {
            while (true)
            {
                string input = ReadRequired("Email", 50);

                if (input.Contains('@') && input.Contains('.'))
                    return input;

                Console.WriteLine("  That doesn't look like an email. Try again.");
            }
        }

        public static DateTime ReadDate(string label)
        {
            while (true)
            {
                Console.Write($"{label.PadRight(15)}: (yyyy MM dd) ");
                string? input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "yyyy MM dd",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out DateTime date)
                    && date < DateTime.Today)
                {
                    return date;
                }

                Console.WriteLine("  Invalid date. Use yyyy MM dd and a date in the past.");
            }
        }

        public static T ReadChoice<T>(int min, int max) where T : Enum
        {
            while (true)
            {
                Console.Write("  Choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice)
                    && choice >= min && choice <= max)
                {
                    return (T)Enum.ToObject(typeof(T), choice);
                }

                Console.WriteLine($"  Please enter a number from {min} to {max}.");
            }
        }

        public static void AddCustomer(BankContext context)
        {
            Console.WriteLine("--- Add New Customer ---");

            string fullName = ReadRequired("Full Name", 50);

            string nationalId;
            while (true)
            {
                nationalId = ReadDigits("National ID", 20);

                if (!context.Customers.Any(c => c.NationalId == nationalId))
                    break;

                Console.WriteLine("  A customer with this National ID already exists.");
            }

            DateTime dateOfBirth = ReadDate("Date of Birth");
            string email = ReadEmail();
            string phone = ReadDigits("Phone", 20);
            string address = ReadRequired("Address", 200);

            Console.WriteLine("Customer Type:\n    1) Individual\n    2) Business");
            CustomerType customerType = ReadChoice<CustomerType>(1, 2);

            var customer = new Customer
            {
                FullName = fullName,
                NationalId = nationalId,
                Email = email,
                DateOfBirth = dateOfBirth,
                PhoneNumber = phone,
                Address = address,
                CustomerType = customerType
            };

            context.Customers.Add(customer);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nCustomer created successfully. CustomerId = {customer.Id}");
            Console.ResetColor();
        }

        public static void OpenAccount(BankContext context)
        {
            Console.WriteLine("--- Open New Account ---");

            string accountNumber = ReadDigits("Account Number", 20);
            if (context.Accounts.Any(a => a.AccountNumber == accountNumber))
            {
                Console.WriteLine("  An account with this number already exists.");
                return;
            }

            Console.WriteLine("Account Type:\n    1) Savings\n    2) Current\n    3) Business");
            AccountType type = ReadChoice<AccountType>(1, 3);

            string branchCode = ReadRequired("Branch Code", 20);
            if (context.Branches.Find(branchCode) == null)
            {
                Console.WriteLine("  A branch with this code does not exist.");
                return;
            }

            int customerId = ReadInt("Customer Id");

            if(context.Customers.Find(customerId) == null)
            {
                Console.WriteLine("  A customer with this ID does not exist.");
                return;
            }

            Console.WriteLine(" Ownership Role:\n 1) Primary\n  2) CoHolder");
            OwnershipType Type = ReadChoice<OwnershipType>(1, 2);

            var account = new Account
            {
                AccountNumber = accountNumber,
                AccountType = type,
                BranchCode = branchCode,
                OpeningDate = DateTime.Now
            };

            var link = new CustomerAccount
            {
                CustomerId = customerId,
                AccountNumber = accountNumber,
                OwnershipType = Type,
                OwnershipStartDate = DateTime.Now,
                AccountStatus = AccountStatus.Active
            };

            context.Accounts.Add(account);
            context.CustomerAccounts.Add(link);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nValidating account creation for Branch: '{account.BranchCode}' and Customer: #{customerId}...");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nAccount '{account.AccountNumber}' created and linked to Customer {customerId} as {Type} owner.");
            Console.ResetColor();
        }

        public static void UpdateAccountStatus(BankContext context)
        {
            Console.WriteLine("--- Update Account Status ---");
            string accountNumber = ReadDigits("Account Number", 20);
            if (context.Accounts.Find(accountNumber) == null)
            {
                Console.WriteLine("  An account with this number does not exist.");
                return;
            }

            int customerId = ReadInt("Customer Id");
            if (context.Customers.Find(customerId) == null)
            {
                Console.WriteLine("  A customer with this ID does not exist.");
                return;
            }

            var link = context.CustomerAccounts.Find(customerId, accountNumber);

            if (link == null)
            {
                Console.WriteLine("  This customer is not linked to that account.");
                return;
            }
            Console.WriteLine("Account Status:\n    1) Active\n    2) Closed");
            AccountStatus newStatus = ReadChoice<AccountStatus>(1, 2);

            var customerAccounts = context.CustomerAccounts.Where(ca => ca.AccountNumber == accountNumber).ToList();
            foreach (var ca in customerAccounts)
            {
                ca.AccountStatus = newStatus;
            }
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Status updated to {newStatus}.");
            Console.ResetColor();
        }

        public static void RemoveAccount(BankContext context)
        {
            Console.WriteLine("--- Remove Account From Customer ---");

            string accountNumber = ReadDigits("Account Number", 20);
            if (context.Accounts.Find(accountNumber) == null)
            {
                Console.WriteLine("  An account with this number does not exist.");
                return;
            }

            int customerId = ReadInt("Customer ID");
            if (context.Customers.Find(customerId) == null)
            {
                Console.WriteLine("  A customer with this ID does not exist.");
                return;
            }

            var link = context.CustomerAccounts.Find(customerId, accountNumber);

            if (link == null)
            {
                Console.WriteLine("  This customer is not linked to that account.");
                return;
            }
            context.CustomerAccounts.Remove(link);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ownership link deleted.");

            if (!context.CustomerAccounts.Any(ca => ca.AccountNumber == accountNumber))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"that was the last owner - account '{accountNumber}' is also removed");
                context.Accounts.Remove(context.Accounts.Find(accountNumber));
                return;
            }
            context.SaveChanges();
            Console.ResetColor();
        }

        public static void ListAllCustomers(BankContext context)
        {
            Console.WriteLine("--- all Customers ---");
            
            var accounts = context.CustomerAccounts
                .Select(ca => new
                {
                    ca.Account.AccountType,
                    ca.CustomerId,
                    ca.Customer.FullName,
                    ca.Account.BranchCode,
                    ca.Account.CurrentBalance,
                    ca.Customer.CustomerType,
                    ca.AccountStatus,
                    ca.OwnershipType,
                    ca.Customer.Address
                })
                .ToList();

            foreach (var account in accounts)
            {
                Console.WriteLine($" #{account.CustomerId} {account.FullName} ({account.CustomerType})\n         {account.BranchCode}  {account.AccountType}   Balance:   {account.CurrentBalance}  {account.OwnershipType} {account.AccountStatus} @ {account.Address}");
            }
        }
    }
}