using NationalBank;
using static NationalBank.HelperMethodes;

namespace NationalBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new BankContext();
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("    National Bank - Management");
                Console.WriteLine("=======================================");
                Console.WriteLine("  1) Add a new Customer");
                Console.WriteLine("  2) Open a new Account for a Customer");
                Console.WriteLine("  3) Update Account Status (Active / Closed)");
                Console.WriteLine("  4) Remove an Account from a Customer");
                Console.WriteLine("  5) List all Customers (with accounts)");
                Console.WriteLine("  0) Exit");
                Console.WriteLine("---------------------------------------");

                choice = ReadInt("Enter choice");
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddCustomer(context);
                            break;
                        case 2:
                            OpenAccount(context);
                            break;
                        case 3:
                            UpdateAccountStatus(context);
                            break;
                        case 4:
                            RemoveAccount(context);
                            break;
                        case 5:
                            ListAllCustomers(context);
                            break;
                        case 0:
                            Console.WriteLine("Goodbye!");
                            break;
                        default:
                            Console.WriteLine("  Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"  Something went wrong: {ex.Message}");
                    Console.ResetColor();
                    context.ChangeTracker.Clear();
                }

                if (choice != 0)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey(true);
                }

            } while (choice != 0);
        }
    }
}