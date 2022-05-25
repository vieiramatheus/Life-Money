using LifeMoney.Domain.Banking;

namespace LifeMoney.Domain
{
    public class User
    {
        private List<BankAccount> _bankAccounts;

        public User()
        {
            Name = string.Empty;
            Wallet = new Wallet();
            _bankAccounts = new List<BankAccount>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<BankAccount> BankAccounts { get => _bankAccounts; }

        public Wallet Wallet { get; set; }

        public void AddBankAccount(BankAccount bankAccount)
        {
            _bankAccounts.Add(bankAccount);
        }
    }
}
