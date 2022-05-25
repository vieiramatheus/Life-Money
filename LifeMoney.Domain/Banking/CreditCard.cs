using LifeMoney.Domain.Base;
using LifeMoney.Domain.Horology;

namespace LifeMoney.Domain.Banking
{
    public class CreditCard : IPaymentMethod
    {
        private readonly List<CreditCardBill> _bills;

        public CreditCard()
        {
            _bills = new List<CreditCardBill>();
        }

        public string? Description { get; set; }

        public int DueDay { get; set; }

        public int ClosingDay { get; set; }

        public IEnumerable<CreditCardBill> Bills => _bills;

        public void Pay(string description, decimal value)
        {
            var paymentRecord = new Record()
            {
                Description = description,
                Value = value,
                Reference = SpaceTime.This.Now
            };

            Pay(paymentRecord);
        }

        public void Pay(string description, decimal value, DateTime reference)
        {
            if (reference > SpaceTime.This.Today)
                throw new InvalidDataException("Not possible to insert a payment with future reference");

            var paymentRecord = new Record
            {
                Description = description,
                Value = value,
                Reference = reference
            };

            Pay(paymentRecord);
        }

        private void Pay(Record paymentRecord)
        {
            var referenceBill = Bills.SingleOrDefault(
                            bill =>
                            bill.OpeningDate >= paymentRecord.Reference &&
                            bill.ClosingDate <= paymentRecord.Reference);

            if (referenceBill == null)
            {
                OpenNewBillWith(paymentRecord);
            }
        }

        private void OpenNewBillWith(Record payment)
        {
            var closingDate = new DateTime(SpaceTime.This.Today.Year, SpaceTime.This.Today.Month, ClosingDay);
            if (closingDate < SpaceTime.This.Today)
                closingDate = closingDate.AddMonths(1);

            var dueDate = new DateTime(SpaceTime.This.Today.Year, SpaceTime.This.Today.Month, DueDay);
            if (dueDate < closingDate)
                dueDate = dueDate.AddMonths(1);

            var bill = new CreditCardBill
            {
                ClosingDate = closingDate,
                DueDate = dueDate
            };

            _bills.Add(bill);

            bill.Register(payment);
        }
    }
}
