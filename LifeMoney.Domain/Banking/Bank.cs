using LifeMoney.Domain.Banking.Base;

namespace LifeMoney.Domain.Banking
{
    public partial class Bank
    {
        private readonly List<BankAccount> _bankAccounts;

        public Bank()
        {
            _bankAccounts = new List<BankAccount>();
        }

        public IEnumerable<BankAccount> BankAccounts { get => _bankAccounts; }

        public IBankAccountCreator CreateAccount()
        {
            return new BankAccountCreator(this);
        }

        public ICreditCardCreator CreateCreditCard()
        {
            return new CreditCardCreator();
        }

        public BankAccount? CreatedAccount { get; private set; }

        private void AddBankAccount(BankAccount bankAccount)
        {
            _bankAccounts.Add(bankAccount);
        }
    }
}
