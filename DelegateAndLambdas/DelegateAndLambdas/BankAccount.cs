using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndLambdas
{
    internal class BankAccount
    {
        private decimal balance;

        public event EventHandler<decimal> Deposited;
        public event EventHandler<decimal> Withdrew;
        public event EventHandler<decimal> BalanceBelowThreshold;

        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
            Deposited?.Invoke(this, amount);
        }

        public void Withdraw(decimal amount)
        {
            if (balance - amount < 0)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            balance -= amount;
            Withdrew?.Invoke(this, amount);

            if (balance < 100)  // Let's assume 100 is our threshold.
            {
                BalanceBelowThreshold?.Invoke(this, balance);
            }
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }
}
