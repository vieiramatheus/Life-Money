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
    public class BankCreateBankAccountTests
    {
        private User _user;
        private Bank _bank;
        private BankAccount _bankAccount;

        [TestInitialize]
        public void Initializer()
        {
            _user = new User();
            _bank = new Bank();
            _bankAccount = _bank.CreateAccount()
                .WithAgencyNumber("123")
                .WithAccountNumber("1234")
                .ForUser(_user).Get();
        }

        [TestMethod]
        public void BankCanCreateAccountTest()
        {
            Assert.AreEqual(1, _bank.BankAccounts.Count());            
        }
        
        [TestMethod]
        public void UserCanHaveBankAccountTest()
        {
            Assert.AreEqual(1, _user.BankAccounts.Count());            
        }

        [TestMethod]
        public void BankAccountWillHavePropperAccountNumberTest()
        {
            Assert.AreEqual("1234", _bankAccount.AccountNumber);            
        }

        [TestMethod]
        public void BankAccountWillHavePropperAgencyNumberTest()
        {
            Assert.AreEqual("123", _bankAccount.AgencyNumber);
        }
    }
}
