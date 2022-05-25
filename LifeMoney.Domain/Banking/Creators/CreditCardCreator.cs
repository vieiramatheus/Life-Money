using LifeMoney.Domain.Banking.Base;

namespace LifeMoney.Domain.Banking
{

    public partial class Bank
    {
        private class CreditCardCreator : ICreditCardCreator
        {
            private readonly CreditCard _creditCard;

            public CreditCardCreator()
            {
                _creditCard = new CreditCard();
            }

            public ICreditCardCreator For(BankAccount bankAccount)
            {
                bankAccount.AddCreditCard(_creditCard);
                return this;
            }

            public ICreditCardCreator WithClosingDayEquals(int value)
            {
                _creditCard.ClosingDay = value;
                return this;
            }

            public ICreditCardCreator WithDueDayEquals(int value)
            {
                _creditCard.DueDay = value;
                return this;
            }

            public ICreditCardCreator WithLimitValueEquals(decimal value)
            {
                return this;                
            }

            public CreditCard Get()
            {
                return _creditCard;
            }
        }
    }
    
}
