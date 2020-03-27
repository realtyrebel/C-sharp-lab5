using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Transaction
    {
        public double Amount { get; set; }

        public Enums.TransactionType Type { get; set; }

        public DateTime TransactionDate { get; set; }

        //Constructor
        public Transaction(double amount, Enums.TransactionType transactionType )
        {
            this.Amount = amount;
            this.Type = transactionType;
            this.TransactionDate = DateTime.Now;
        }
    }
}
