namespace LifeMoney.Domain.Base
{
    public interface IPaymentMethod
    {
        public void Pay(string description, decimal value);

        public void Pay(string description, decimal amount, DateTime reference);
    }
}
