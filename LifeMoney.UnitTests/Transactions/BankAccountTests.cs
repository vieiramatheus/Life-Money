using LifeMoney.Domain;
using LifeMoney.Domain.Banking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeMoney.UnitTests
{
    [TestClass]
    public class BankAccountTests
    {
        private Wallet _wallet = new();
        private BankAccount _bankAccount = new();

        [TestInitialize]
        public void Initializer()
        {
            _wallet = new Wallet();
            _bankAccount = new BankAccount();
            var withdrawee = _bankAccount.Withdraw(10);
            _bankAccount.CalculateBalance();

            _wallet.Deposit(withdrawee);
            _wallet.CalculateBalance();
        }

        [TestMethod]
        public void CanCalculateBankAccountBalanceAccordinglyWithOriginAndDestinyTest()
        {
            Assert.AreEqual(_bankAccount.Balance, -10m);
        }

        [TestMethod]
        public void CanCalculateWalletBalanceAccordinglyWithOriginAndDestinyTest()
        {
            Assert.AreEqual(_wallet.Balance, 10m);
        }

        [TestMethod]
        public void CanHaveDestinyAsSameWalletTest()
        {
            var record = _bankAccount.Outs.First();
            Assert.AreSame(_wallet, record.Destiny);
        }

        [TestMethod]
        public void CanHaveOriginSameAsBankAccountTest()
        {
            var record = _wallet.Ins.First();
            Assert.AreSame(_bankAccount, record.Origin);
        }
    }
}
