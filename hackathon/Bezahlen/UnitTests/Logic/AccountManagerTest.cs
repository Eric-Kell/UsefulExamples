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
      int sum = MoqDataGenerator.GetRandomNumber(10, 100);
      var account = await accountManager.CreateAccount(name, sum);
      var last = data.Accounts.Data.Last();
      Assert.AreSame(account, last);
      Assert.AreEqual(amount + 1, data.Accounts.Data.Count());
      Assert.AreEqual(name, last.Name);
      Assert.AreEqual(sum, last.TargetSum);
    }

    [TestMethod]
    public async Task BindUserToAccountByLogins()
    {
      var account = data.Accounts.Data.First();
      int amount = data.UserAccounts.Data.Count();
      var user = data.Users.Data.First();
      await accountManager.BindUserToAccountByUserId(account, user.UserID);
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

    [TestMethod]
    public void GetUserAccountsTest()
    {
      var account = data.Accounts.Data.First();
      var user = data.Users.Data.First();
      var result = accountManager.GetUserAccounts(user);
      Assert.AreEqual(1, result.Count());
      Assert.AreSame(account, result.First());
    }

    [TestMethod]
    public void GetOwnersLoginsTest()
    {
      var account = data.Accounts.Data.First();
      var user = data.Users.Data.First();
      var result = accountManager.GetOwnersLogins(account);
      Assert.AreEqual(result.Count, 1);
      Assert.AreEqual(user.Login, result.First());
    }

    [TestMethod]
    public void GetUserBalanceTest()
    {
      var account = data.Accounts.Data.First();
      var user = data.Users.Data.First();
      var payment = data.Payments.Data.First();
      var result = accountManager.GetUserBalance(user, account);
      Assert.AreEqual(result, 0);
    }

    [TestMethod]
    public async Task RemoveUserFromAccountTest()
    {
      var account = data.Accounts.Data.First();
      var user = data.Users.Data.First();
      var amount = data.UserAccounts.Data.Count();
      Assert.AreNotEqual(null, data.UserAccounts.Data.FirstOrDefault(x => x.User == user && x.Account == account));
      await accountManager.RemoveUserFromAccount(user, account);
      Assert.AreEqual(amount - 1, data.UserAccounts.Data.Count());
      Assert.AreEqual(null, data.UserAccounts.Data.FirstOrDefault(x => x.User == user && x.Account == account));
    }

  }
}
