namespace LifeMoney.Domain.Banking.Base
{
    public interface IDebitCardCreator
    {
        IDebitCardCreator With(string name);

        DebitCard Get();
    }
}
