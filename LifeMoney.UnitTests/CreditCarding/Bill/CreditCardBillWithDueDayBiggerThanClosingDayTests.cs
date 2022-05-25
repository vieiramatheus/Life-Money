using LifeMoney.Domain;
using LifeMoney.Domain.Banking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LifeMoney.UnitTests.CreditCarding.Bill
{
    [TestClass]
    public class CreditCardBillWithDueDayBiggerThanClosingDayTests
    {
        private const int _closingDay = 10;
        private const int _dueDay = 15;
        CreditCard _creditCard = new();

        [TestInitialize]
        public void Initializer()
        {
            Delorean.TravelTo(new DateTime(2022, 04, 16));

            var user = new User();
            var bank = new Bank();
            var bankAccount = bank.CreateAccount()
                .WithAgencyNumber("1234")
                .WithAccountNumber("123")
                .ForUser(user)
                .Get();

            _creditCard = bank.CreateCreditCard()
                .For(bankAccount)
                .WithClosingDayEquals(_closingDay)
                .WithDueDayEquals(_dueDay)
                .WithLimitValueEquals(1000)
                .Get();

            _creditCard.Pay(description: "Teste de Unidade", value: 599.30m);
        }

        [TestMethod]
        public void CanInsertRecordsOnNewBillTest()
        {
            Assert.AreEqual(1, _creditCard.Bills.Count());
        }

        [TestMethod]
        public void CanCreateBillWithCorrectClosingDateTest()
        {
            var bill = _creditCard.Bills.First();

            Assert.AreEqual(new DateTime(2022, 05, 10), bill.ClosingDate);
        }

        [TestMethod]
        public void CanCreateBillWithCorrectDueDateTest()
        {
            var bill = _creditCard.Bills.First();

            Assert.AreEqual(new DateTime(2022, 05, 15), bill.DueDate);
        }

        [TestMethod]
        public void CanCreatePaymentRecordWithCorrectDescriptionTest()
        {
            var bill = _creditCard.Bills.First();
            var record = bill.Outs.First();
            Assert.AreEqual("Teste de Unidade", record.Description);
        }

        [TestMethod]
        public void CanCreatePaymentWithCorrectValueTest()
        {
            var bill = _creditCard.Bills.First();
            var record = bill.Outs.First();
            Assert.AreEqual(599.30m, record.Value);
        }

        [TestMethod]
        public void CanCreatePaymentWithCorrectReferenceTest()
        {
            var bill = _creditCard.Bills.First();
            var record = bill.Outs.First();
            Assert.AreEqual(new DateTime(2022, 04, 16), record.Reference);
        }
    }
}
