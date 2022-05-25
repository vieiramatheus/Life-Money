namespace LifeMoney.Domain.Banking.Base
{
    public interface ICreditCardCreator
    {
        ICreditCardCreator WithDueDayEquals(int value);

        ICreditCardCreator WithClosingDayEquals(int value);

        ICreditCardCreator WithLimitValueEquals(decimal value);

        ICreditCardCreator For(BankAccount bankAccount);

        CreditCard Get();


    }
}
