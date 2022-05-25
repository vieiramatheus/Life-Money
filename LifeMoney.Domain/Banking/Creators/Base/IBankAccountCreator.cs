namespace LifeMoney.Domain.Banking.Base
{
    public interface IBankAccountCreator
    {
        IBankAccountCreator WithAccountNumber(string number);
        IBankAccountCreator WithAgencyNumber(string number);
        IBankAccountCreator ForUser(User user);

        BankAccount Get();
    }
}