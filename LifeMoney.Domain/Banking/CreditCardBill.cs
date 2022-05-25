using LifeMoney.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeMoney.Domain.Banking
{
    public class CreditCardBill : IRecorder
    {
        private readonly List<Record> _shoppings;
        private readonly List<Record> _billPayments;

        public CreditCardBill()
        {
            _shoppings = new List<Record>();
            _billPayments = new List<Record>();
        }

        public IEnumerable<Record> Ins => _billPayments;

        public IEnumerable<Record> Outs => _shoppings;

        public DateTime DueDate { get; set; }

        public DateTime OpeningDate { get => ClosingDate.AddMonths(-1); }

        public DateTime ClosingDate { get; set; }

        public int Reference { get; set; } = 0;

        public decimal Balance { get; private set; }

        public void CalculateBalance()
        {
            Balance = _billPayments.Sum(p => p.Value) - _shoppings.Sum(p => p.Value);
        }

        public void Register(Record record)
        {
            _shoppings.Add(record);

            Balance -= record.Value;
        }

        public void PayBill(Record record)
        {
            _billPayments.Add(record);
        }
    }
}
