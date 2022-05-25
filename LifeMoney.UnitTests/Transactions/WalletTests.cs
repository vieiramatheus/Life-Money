using LifeMoney.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LifeMoney.UnitTests
{
    [TestClass]
    public class WalletTests
    {
        private Wallet _wallet;

        [TestInitialize]
        public void Initializer()
        {
            _wallet = new Wallet();
            _wallet.Deposit(new Record { Value = 20 });
            _wallet.Withdraw(10);
            _wallet.CalculateBalance();            
        }

        [TestMethod]
        public void CanRegisterDepositMoneyToWalletTest()
        {
            Assert.AreEqual(1, _wallet.Ins.Count());
        }

        [TestMethod]
        public void CanRegisterWithdrawMoneyFromWalletTest()
        {
            Assert.AreEqual(1, _wallet.Outs.Count());
        }

        [TestMethod]
        public void CanCalculateBalanceFromWalletTest()
        {
            Assert.AreEqual(10, _wallet.Balance);
        }
    }
}
