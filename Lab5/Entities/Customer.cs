using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Customer
    {
        //initialize variables
        public string Name { get; }
        public Enums.CustomerStatus Status { get; set; }
        public ChequingAccount ChequingAccount { get; set; }

        public SavingsAccount SavingsAccount { get; set; }

        //CLASS CONSTRUCTOR
        public Customer(string name, double initialSavingsDeposit)
        {
            //set Name
            this.Name = name;

            //set Status
            if (initialSavingsDeposit >= SavingsAccount.PremierAmount)
            {
                this.Status = Enums.CustomerStatus.PREMIER;
            }
            else
            {
                this.Status = Enums.CustomerStatus.REGULAR;
            }

            //create new ChequingAccount
            double initialChequingDeposit = 0.0;
            this.ChequingAccount = new ChequingAccount(initialChequingDeposit, this);

            //create new SavingsAccount
            this.SavingsAccount = new SavingsAccount(initialSavingsDeposit, this);

            //create new Transaction and save in TransactionHistory
            Transaction newDeposit = new Transaction(initialSavingsDeposit, Enums.TransactionType.DEPOSIT);
            this.SavingsAccount.TransactionHistory.Add(newDeposit);
        }
    }
}
    
