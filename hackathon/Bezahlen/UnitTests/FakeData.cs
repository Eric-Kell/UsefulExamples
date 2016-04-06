using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Data.DB;
namespace UnitTests
{
  public class FakeData : IData
  {
    public IRepository<Account> Accounts { get; } = new FakeRepository<Account>();
    public IRepository<Payment> Payments { get; } = new FakeRepository<Payment>();
    public IRepository<User> Users { get; } = new FakeRepository<User>();
    public IRepository<UserAccount> UserAccounts { get; } = new FakeRepository<UserAccount>();
    public IRepository<Token> Tokens { get; } = new FakeRepository<Token>(); 

    public FakeData()
    {
      AsyncHelpers.RunSync(FillWithTestData);
    }

    private async Task FillWithTestData()
    {
      // создаем объекты
      var user = new User
      {
        Login = MoqDataGenerator.GetRandomString(10),
        Password = MoqDataGenerator.GetRandomString(10),
        Nickname = MoqDataGenerator.GetRandomString(10),
        UserID = MoqDataGenerator.GetRandomNumber(1,100)
      };

      var account = new Account
      {
        AccountID = MoqDataGenerator.GetRandomNumber(1, 100),
        Name = MoqDataGenerator.GetRandomString(10),
        Description = MoqDataGenerator.GetRandomString(100)
      };

      var payment = new Payment
      {
        Date = DateTime.Now,
        PaymentID = MoqDataGenerator.GetRandomNumber(1, 100),
        Value = MoqDataGenerator.GetRandomNumber(1, 1000),
        Text = MoqDataGenerator.GetRandomString(1000)
      };

      var userAccount = new UserAccount
      {
        UserAccountID = MoqDataGenerator.GetRandomNumber(1, 100)
      };

      var token = new Token
      {
        Value = MoqDataGenerator.GetRandomString(10)
      };


      // устанавливаем связи
      account.UserAccounts = new List<UserAccount> {userAccount};
      account.Payments = new List<Payment> {payment};
      payment.User = user;
      payment.UserID = user.UserID;
      payment.Account = account;
      user.UserAccounts = new List<UserAccount> {userAccount};
      user.Payments = new List<Payment> {payment};
      userAccount.User = user;
      userAccount.Account = account;
      userAccount.UserID = user.UserID;
      userAccount.AccountID = account.AccountID;
      token.User = user;
      token.UserID = user.UserID;

      await Accounts.AddAsync(account);
      await Payments.AddAsync(payment);
      await Users.AddAsync(user);
      await UserAccounts.AddAsync(userAccount);
      await Tokens.AddAsync(token);

    }
  }
}
