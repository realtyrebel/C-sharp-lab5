using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class ChequingAccount : Account
    {
        //STATIC PROPERTIES
        public static double MaxWithdrawAmount = 300.0;

        //Constructor
        public ChequingAccount(double initialDeposit, Customer owner)
            : base(initialDeposit, owner)
        {
            //base Account class takes all initial variables
        }

        public override void Deposit(double amount, Enums.TransactionType transactionType)
        {
            base.Deposit(amount, transactionType);
        }

        public override void Withdraw(double amount, Enums.TransactionType transactionType)
        {
            //check to see if there are available funds
            if (amount <= this.Balance)
            {
                //if (Owner.Status == Enums.CustomerStatus.REGULAR && amount > MaxWithdrawAmount)
                if (Owner.Status == Enums.CustomerStatus.REGULAR && amount > MaxWithdrawAmount)
                {
                    throw new Exception("Withdrawal cancelled: Exceeds maximum withdrawal limit of $300 for Customers having REGULAR Status.");
                }
                else
                {
                    //either Premier Account OR less than MaxWithdrawAmount
                    base.Withdraw(amount, transactionType);
                }
            }
            else
            {
                throw new Exception("Withdrawal cancelled: INSUFFICIENT_FUNDS");
            }            
        }
    }
}
