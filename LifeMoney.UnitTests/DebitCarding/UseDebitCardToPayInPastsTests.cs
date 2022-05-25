using System;
using System.Linq;
using LifeMoney.Domain;
using LifeMoney.Domain.Banking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeMoney.UnitTests.DebitCarding
{
    [TestClass]
    public class UseDebitCardToPayInPastsTests
    {
        private DebitCard _debitCard;
        private DateTime _testDate = new DateTime(2022, 05, 17);

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

            _debitCard = bankAccount.CreateDebitCard().With(name: "Cartão de Teste").Get();
            _debitCard.Pay(description: "Pagamento de Teste", amount: 100, reference: _testDate);
        }

        [TestMethod]
        public void CanHaveDebitCardWithCorrectNameTests()
        {
            Assert.AreEqual("Cartão de Teste", _debitCard.Name);
        }

        [TestMethod]
        public void CanRegisterPaymentWithCorrectNameTests()
        {
            var lastRecord = _debitCard.BankAccount.Outs.Last();

            Assert.AreEqual("Pagamento de Teste", lastRecord.Description);
        }

        [TestMethod]
        public void CanRegisterPaymentNowTests()
        {
            var lastRecord = _debitCard.BankAccount.Outs.Last();

            Assert.AreEqual(_testDate, lastRecord.Reference);
        }

        [TestMethod]
        public void CanHaveBankAccountOutsEqualsOneTests()
        {
            Assert.AreEqual(1, _debitCard.BankAccount.Outs.Count());
        }
    }
}
