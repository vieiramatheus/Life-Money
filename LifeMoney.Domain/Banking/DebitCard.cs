using LifeMoney.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeMoney.Domain.Banking
{
    public class DebitCard : IPaymentMethod
    {
        public BankAccount? BankAccount { get; set; }
        public string Name { get; internal set; }

        public void Pay(string description, decimal amount)
        {
            if (BankAccount == null)
                throw new InvalidOperationException("The debit card does not posses a bank account attached to him");

            var paymentRecord = BankAccount.Withdraw(amount);
            paymentRecord.Description = description;
        }

        public void Pay(string description, decimal amount, DateTime reference)
        {
            if (BankAccount == null)
                throw new InvalidOperationException("The debit card does not posses a bank account attached to him");

            var paymentRecord = BankAccount.Withdraw(amount);
            paymentRecord.Description = description;
            paymentRecord.Reference = reference;
        }
    }
}
