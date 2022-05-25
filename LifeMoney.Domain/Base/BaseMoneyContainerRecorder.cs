namespace LifeMoney.Domain
{
    public abstract class BaseMoneyContainerRecorder : IRecorder, IMoneyContainer
    {
        protected List<Record> _ins;
        protected List<Record> _outs;

        public BaseMoneyContainerRecorder()
        {
            _ins = new List<Record>();
            _outs = new List<Record>();            
            Balance = 0m;
        }

        public IEnumerable<Record> Ins { get => _ins; }
        
        public IEnumerable<Record> Outs { get => _outs; }
        
        public decimal Balance { get; private set; }

        public void Deposit(Record record)
        {
            if (record.Destiny == null)
                record.Destiny = this;

            _ins.Add(record);

            Balance += record.Value;
        }

        public Record Withdraw(decimal value)
        {
            var result = new Record { Origin = this, Value = value };

            _outs.Add(result);

            Balance -= value;

            return result;
        }

        public void CalculateBalance()
        {
            Balance = _ins.Sum(p => p.Value) - _outs.Sum(p => p.Value);
        }
    }
}
