using LifeMoney.Domain;
using LifeMoney.Domain.Banking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LifeMoney.UnitTests.CreditCarding.Bill
{
    [TestClass]
    public class CreditCardBillWithDueDayLesserThanClosingDayTests
    {
        private CreditCard _creditCard = new();

        private const int _dueDay = 1;
        private const int _closingDay = 20;

        private DateTime _testDate = new DateTime(2022, 04, 16);

        [TestInitialize]
        public void Initializer()
        {
            Delorean.TravelTo(_testDate);

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
        public void CanHaveClosingDateBeforeDueDateTest()
        {
            var bill = _creditCard.Bills.First();

            Assert.IsTrue(bill.ClosingDate < bill.DueDate);
        }

        [TestMethod]
        public void CanHaveCorrectClosingDateTest()
        {
            var bill = _creditCard.Bills.First();

            Assert.AreEqual(new DateTime(2022, 04, 20), bill.ClosingDate);
        }

        [TestMethod]
        public void CanHaveCorrectDueDateTest()
        {
            var bill = _creditCard.Bills.First();

            Assert.AreEqual(new DateTime(2022, 05, 1), bill.DueDate);
        }
    }
}
