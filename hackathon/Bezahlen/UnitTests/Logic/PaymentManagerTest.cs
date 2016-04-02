using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Logic
{
  [TestClass]
  public class PaymentManagerTest : LogicTest
  {
    private PaymentManager paymentManager;

    public PaymentManagerTest()
    {
      paymentManager = new PaymentManager(data);
    }

    [TestMethod]
    public async Task CreatePaymentTest()
    {
      var user = data.Users.Data.First();
      var account = data.Accounts.Data.First();
      var text = MoqDataGenerator.GetRandomString(10);
      var value = MoqDataGenerator.GetRandomNumber(1, 100);
      var date = DateTime.Now;
      int amount = data.Payments.Data.Count();
      await paymentManager.CreatePayment(text, date, user, account, value);
      Assert.AreEqual(amount + 1, data.Payments.Data.Count());
      var result = data.Payments.Data.Last();
      Assert.AreSame(result.User, user);
      Assert.AreSame(result.Account, account);
      Assert.AreEqual(text, result.Text);
      Assert.AreEqual(value, result.Value);
      Assert.AreEqual(date, result.Date);
    }

  }
}
