using LifeMoney.Domain.Banking.Base;

namespace LifeMoney.Domain.Banking
{
    public partial class BankAccount
    {
        public class DebitCardCreator : IDebitCardCreator
        {
            private string _debitCardName;
            private readonly BankAccount _bankAccount;

            public DebitCardCreator(BankAccount bankAccount)
            {
                _bankAccount = bankAccount;
                _debitCardName = string.Empty;
            }

            public DebitCard Get()
            {
                return new DebitCard()
                {
                    Name = _debitCardName,
                    BankAccount = _bankAccount
                };
            }

            public IDebitCardCreator With(string name)
            {
                _debitCardName = name;

                return this;
            }
        }
    }
    
}
