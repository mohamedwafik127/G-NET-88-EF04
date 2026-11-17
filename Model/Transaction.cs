
using System;
using System.Collections.Generic;
using System.Text;

namespace NationalBank.Model
{
    public class Transaction
    {
        public int TransactionNumber { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Note { get; set; }
        public string AccountNumber { get; set; } = null!;
        public Account Account { get; set; } = null! ;
    }
}
