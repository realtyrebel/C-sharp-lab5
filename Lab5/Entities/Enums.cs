using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Enums
    {
        public enum CustomerStatus
        {
            REGULAR,
            PREMIER
        }

        public enum TransactionResult
        {
            SUCCESS,
            INSUFFICIENT_FUNDS,
            EXCEEDS_MAX_WITHDRAW_AMOUNT
        }

        public enum TransactionType
        {
            DEPOSIT,
            WITHDRAWAL,
            PENALTY,
            TRANSFER_OUT,
            TRANSFER_IN
        }
    }
}
