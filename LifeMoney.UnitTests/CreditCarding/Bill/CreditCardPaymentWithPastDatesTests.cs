using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeMoney.Domain;
using LifeMoney.Domain.Banking;

namespace LifeMoney.UnitTests.CreditCarding.Bill
{
    [TestClass]
    public class CreditCardPaymentWithPastDatesTests
    {
        private const decimal _value = 420m;
        private const string _description = "Teste de Unidade";
        private DateTime _paymentDate;
        private Record _record;
        private CreditCard _creditCard;

        [TestInitialize]
        public void Initialize()
        {
            Delorean.TravelTo(new DateTime(2022, 04, 27));

            _paymentDate = new DateTime();

            var user = new User();
            var bank = new Bank();
            var bankAccount = bank.CreateAccount()
                .WithAgencyNumber("1234")
                .WithAccountNumber("123")
                .ForUser(user)
                .Get();

            _creditCard = bank.CreateCreditCard()
                .For(bankAccount)
                .WithClosingDayEquals(10)
                .WithDueDayEquals(25)
                .WithLimitValueEquals(1000)
                .Get();

            _creditCard.Pay(description: _description, value: _value, reference: _paymentDate);

            _record = _creditCard.Bills.First().Outs.First();
        }

        [TestMethod]
        public void CanCreatePaymentWithDateInPastTest()
        {
            Assert.AreEqual(_paymentDate, _record.Reference);
        }

        [TestMethod]
        public void CanCreatePaymentWithCorrectValueTest()
        {
            Assert.AreEqual(_value, _record.Value);
        }

        [TestMethod]
        public void CanCreatePaymentWithCorrectDescription()
        {
            Assert.AreEqual(_description, _record.Description);
        }
    }
}
