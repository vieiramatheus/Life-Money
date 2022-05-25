using LifeMoney.Domain.Banking.Base;

namespace LifeMoney.Domain.Banking
{
    public partial class BankAccount : BaseMoneyContainerRecorder
    {
        private readonly List<CreditCard> _creditCards;
        private readonly List<DebitCard> _debitCards;

        public BankAccount()
        {
            _ins = new List<Record>();
            _outs = new List<Record>();
            _creditCards = new List<CreditCard>();

            AccountNumber = string.Empty;
            AgencyNumber = string.Empty;
        }

        public string AccountNumber { get; set; }

        public string AgencyNumber { get; set; }

        public IEnumerable<CreditCard> CreditCards { get => _creditCards; }

        public IEnumerable<DebitCard> DebitCards { get => _debitCards; }

        public IDebitCardCreator CreateDebitCard()
        {
            return new DebitCardCreator(this);
        }

        public void AddCreditCard(CreditCard creditCard)
        {
            _creditCards.Add(creditCard);
        }
    }
}
