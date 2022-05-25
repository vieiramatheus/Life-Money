using LifeMoney.Domain.Banking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeMoney.UnitTests.CreditCarding.Bill
{
    [TestClass]
    public class CreditCardBillClosingDateTests
    {
        [DataTestMethod]
        [DataRow("2022-04-15", "2022-03-15")]
        [DataRow("2019-08-28", "2019-07-28")]
        [DataRow("2023-12-27", "2023-11-27")]
        [TestMethod]
        public void CreditCardBillHaveOpeningDateOneDayAfterClosingDateTest(string closingDate, string expectedDate)
        {
            var creditCardBill = new CreditCardBill
            {
                ClosingDate = closingDate.GetDateTime()
            };

            Assert.AreEqual(expectedDate.GetDateTime(), creditCardBill.OpeningDate);
        }
    }
}
