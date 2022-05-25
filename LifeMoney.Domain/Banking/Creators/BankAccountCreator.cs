using LifeMoney.Domain.Banking.Base;

namespace LifeMoney.Domain.Banking
{
    public partial class Bank
    {
        private class BankAccountCreator : IBankAccountCreator
        { 
            private readonly BankAccount _bankAccount;
            private readonly Bank _bank;

            public BankAccountCreator(Bank bank)
            {
                _bankAccount = new BankAccount();
                _bank = bank;
            }

            public IBankAccountCreator WithAccountNumber(string number)
            {
                _bankAccount.AccountNumber = number;
                return this;
            }

            public IBankAccountCreator WithAgencyNumber(string number)
            {
                _bankAccount.AgencyNumber = number; 
                return this;
            }

            public IBankAccountCreator ForUser(User user)
            {
                user.AddBankAccount(_bankAccount);
                _bank.AddBankAccount(_bankAccount);
                return this;
            }

            public BankAccount Get()
            {
                return _bankAccount;
            }
        }
    }

}
