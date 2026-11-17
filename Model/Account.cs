using System;
using System.Collections.Generic;
using System.Text;

namespace NationalBank.Model
{
    public class Account
    {
        public string AccountNumber { get; set; } = null!;
        public decimal CurrentBalance { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime OpeningDate { get; set; }
        public string BranchCode { get; set; } = null!;   
        public Branch Branch { get; set; } = null!;
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>();
    }
}
