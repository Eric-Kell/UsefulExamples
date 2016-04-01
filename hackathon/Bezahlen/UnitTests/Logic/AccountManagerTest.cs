using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Logic
{
  [TestClass]
  public class AccountManagerTest : LogicTest
  {
    private AccountManager accountManager;

    public AccountManagerTest()
    {
      accountManager = new AccountManager(data);
    }

    [TestMethod]
    public async Task CreateAccountTest()
    {
      int amount = data.Accounts.Data.Count();
      string name = MoqDataGenerator.GetRandomString(10);
      var account = await accountManager.CreateAccount(name);
      var last = data.Accounts.Data.Last();
      Assert.AreSame(account, last);
      Assert.AreEqual(amount + 1, data.Accounts.Data.Count());
      Assert.AreEqual(name, last.Name);
    }

    [TestMethod]
    public async Task BindUserToAccountByLogins()
    {
      var account = data.Accounts.Data.First();
      int amount = data.UserAccounts.Data.Count();
      var user = data.Users.Data.First();
      await accountManager.BindUserToAccountByLogins(account, new List<string> {user.Login});
      var userAccount = data.UserAccounts.Data.First(x => x.User == user && x.Account == account);
      Assert.AreEqual(amount + 1, data.UserAccounts.Data.Count());
    }

    [TestMethod]
    public void GetAccountByIdTest()
    {
      var account = data.Accounts.Data.First();
      var result = accountManager.GetAccountById(account.AccountID);
      Assert.AreSame(account, result);
    }
  }
}
