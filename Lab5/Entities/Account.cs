using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    //base class
    public class Account
    {
        //private double balance;//cannot access outside of class
        public double Balance
        {            
            get;
            private set;
            //set;

            /*
            get { return balance; }            
            set { balance = value; }
            */
        }

        public Customer Owner { get; set; }

        public List<Transaction> TransactionHistory = new List<Transaction>();//blank list of transactions
               
        //Constructor
        public Account(double initialDeposit, Customer owner)
        {
            this.Balance = initialDeposit;
            this.Owner = owner;            
        }

        //public virtual double  Deposit(double amount)
        public virtual void Deposit(double amount, Enums.TransactionType transactionType)
        {
            this.Balance += Math.Round(amount, 2);

            Transaction newTransaction = new Transaction(amount, transactionType);
            this.TransactionHistory.Add(newTransaction);
        }

        //public void Withdraw(double amount)
        public virtual void Withdraw(double amount, Enums.TransactionType transactionType)
        {
            //check if there is money in the account
            if (this.Balance >= amount)
            {
                this.Balance -= Math.Round(amount, 2);

                Transaction newTransaction = new Transaction(amount, transactionType);
                this.TransactionHistory.Add(newTransaction);
            }
        }
    }
}
