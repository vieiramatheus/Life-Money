namespace LifeMoney.Domain
{
    public interface IMoneyContainer
    {
        void Deposit(Record record);

        Record Withdraw(decimal value);        
    }
}
