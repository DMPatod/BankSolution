using BuildBlocks.Commons;
using CashierManagement.Cashiers;
using MoneyMenagement.Transactions.Events;
using System;
using System.Threading;

namespace MoneyMenagement.Transactions
{
    public class Transaction : Aggregate
    {
        public Guid Id { get; private set; } = default;
        public TransactionType Type { get; set; }
        public decimal HoldValue { get; set; }
        public Cashier Cashier { get; set; }
        public Transaction()
        {
            // Only for EF
        }
        public Transaction(Cashier cashier, TransactionType type, decimal holdValue)
        {
            Type = type;
            HoldValue = holdValue;
            Cashier = cashier;
        }
        public static Transaction Create(Cashier cashier, TransactionType type, decimal transactionValue, CancellationToken cancellationToken)
        {
            if (transactionValue < 0)
            {
                throw new Exception("Valor de operação não pode ser negativo");
            }
            if (cashier.Id <= 0)
            {
                throw new Exception("Transação precisa ser associada a cashier");
            }

            Transaction returnObj;
            switch (type)
            {
                case TransactionType.Deposit:
                    returnObj = new Transaction(cashier, type, transactionValue);
                    var depositEvent = new DepositEvent(returnObj);
                    returnObj.AddDomainEvent(depositEvent);
                    break;
                case TransactionType.Withdrawal:
                    if (cashier.StoredAmount < transactionValue)
                    {
                        throw new Exception("Saldo insuficiente");
                    }
                    returnObj = new Transaction(cashier, type, transactionValue);
                    var withdrawEvent = new WithdrawlEvent(returnObj);
                    returnObj.AddDomainEvent(withdrawEvent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return returnObj;
        }
    }
    public enum TransactionType
    {
        Withdrawal,
        Deposit
    }
}
