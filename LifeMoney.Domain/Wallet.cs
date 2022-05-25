using LifeMoney.Domain.Base;

namespace LifeMoney.Domain
{
    public class Wallet : BaseMoneyContainerRecorder, IPaymentMethod
    {
        public Wallet()
        {
            Name = string.Empty;
        }

        public string Name { get; set; }

        public void Pay(string description, decimal value)
        {
            if (value > Balance)
                throw new InvalidOperationException("Wallet balance is less than payment value");

            var paymentRecord = Withdraw(value);

            paymentRecord.Description = description;
        }

        public void Pay(string description, decimal amount, DateTime reference)
        {
            throw new NotImplementedException();
        }
    }
}