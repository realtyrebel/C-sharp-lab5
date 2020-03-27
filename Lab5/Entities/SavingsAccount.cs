using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class SavingsAccount : Account
    {
        //STATIC PROPERTIES
        public static double PremierAmount = 2000.0;
        public static double WithdrawPenaltyAmount = 10.0;

        //CLASS CONSTRUCTOR
        //create new Savings account
        /*
        public SavingsAccount(string owner, double initialDeposit)
        {
            this.Owner = owner;
            this.balance = initialDeposit;
        }
        */
        public SavingsAccount(double initialDeposit, Customer owner)
            : base(initialDeposit, owner)
        {
            //base Account class takes all initial variables            
        }

        public override void Deposit(double amount, Enums.TransactionType transactionType)
        {
            base.Deposit(amount, transactionType);

            //change Customer Status
            if (this.Balance >= PremierAmount)
            {
                this.Owner.Status = Enums.CustomerStatus.PREMIER;
            }
            else
            {
                this.Owner.Status = Enums.CustomerStatus.REGULAR;
            }
        }

        public override void Withdraw(double amount, Enums.TransactionType transactionType)
        {
            //check to see if there are available funds
            if (amount <= this.Balance)
            {
                base.Withdraw(amount, transactionType);

                //penalty charge for REGULAR customer
                if (this.Owner.Status == Enums.CustomerStatus.REGULAR)
                {
                    base.Withdraw(WithdrawPenaltyAmount, Enums.TransactionType.PENALTY);

                    //change Customer Status
                    if (this.Balance < PremierAmount)
                    {
                        this.Owner.Status = Enums.CustomerStatus.REGULAR;
                    }
                    else
                    {
                        this.Owner.Status = Enums.CustomerStatus.PREMIER;
                    }
                }
            }
            else
            {
                throw new Exception("Withdrawal cancelled: INSUFFICIENT_FUNDS");
            }                
        }
    }
}
