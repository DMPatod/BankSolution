using BuildBlocks.Commons;
using System;

namespace MoneyMenagement.Transactions
{
    public class Transaction : Aggregate
    {
        public Guid Id { get; set; }
        public TransactionType Type { get; set; }
        public decimal HoldValue { get; set; }
        public Transaction()
        {
            if (HoldValue < 0)
            {
                throw new Exception("Transaction value cannot be negative");
            }
        }
    }
    public enum TransactionType
    {
        Withdrawal,
        Deposit
    }
}
