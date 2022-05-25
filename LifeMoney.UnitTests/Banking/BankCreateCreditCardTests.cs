using LifeMoney.Domain;
using LifeMoney.Domain.Banking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LifeMoney.UnitTests
{
    [TestClass]
    public class BankCreateCreditCardTests
    {
        private CreditCard _creditCard;

        [TestInitialize]
        public void Initializer()
        {
            User user = new User();
            Bank bank = new Bank();
            BankAccount bankAccount = bank.CreateAccount()
                .WithAgencyNumber("1234")
                .WithAccountNumber("123")
                .ForUser(user)
                .Get();

            _creditCard = bank.CreateCreditCard()
                .For(bankAccount)
                .WithClosingDayEquals(10)
                .WithDueDayEquals(15)
                .WithLimitValueEquals(1000)                
                .Get();
        }

        [TestMethod]
        public void CreditCardHaveBillsTest()
        {
            Assert.IsNotNull(_creditCard.Bills);
        }

        [TestMethod]
        public void CreditCardHaveIEnumerableOfBillTest()
        {
            Assert.IsInstanceOfType(_creditCard.Bills, typeof(IEnumerable<CreditCardBill>));
        }

        [TestMethod]
        public void CreditCardHaveDueDay()
        {
            Assert.AreEqual(15, _creditCard.DueDay);
        }

        [TestMethod]
        public void CreditCardHaveClosingDay()
        {
            Assert.AreEqual(10m, _creditCard.ClosingDay);
        }
    }
}
