using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;

namespace UnitTests
{
  public class FakeData : IData
  {
    public IRepository<Account> Accounts { get; } = new FakeRepository<Account>();
    public IRepository<AccountPayment> AccountPayments { get; } = new FakeRepository<AccountPayment>();
    public IRepository<Payment> Payments { get; } = new FakeRepository<Payment>();
    public IRepository<Purchase> Purchases { get; } = new FakeRepository<Purchase>();
    public IRepository<User> Users { get; } = new FakeRepository<User>();
    public IRepository<PurchasePayment> PurchasePayments { get; } = new FakeRepository<PurchasePayment>();
    public IRepository<UserAccount> UserAccounts { get; } = new FakeRepository<UserAccount>();
    public IRepository<UserPurchase> UserPurchases { get; } = new FakeRepository<UserPurchase>();

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

      var accountPayment = new AccountPayment
      {
        AccountPaymentID = MoqDataGenerator.GetRandomNumber(1, 100)
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

      var purchase = new Purchase
      {
        PurchaseID = MoqDataGenerator.GetRandomNumber(1, 100),
        Name = MoqDataGenerator.GetRandomString(10),
        Description = MoqDataGenerator.GetRandomString(100)
      };

      var purchasePayment = new PurchasePayment
      {
        PurchasePaymentID = MoqDataGenerator.GetRandomNumber(1, 100)
      };

      var userAccount = new UserAccount
      {
        UserAccountID = MoqDataGenerator.GetRandomNumber(1, 100)
      };

      var userPurchase = new UserPurchase
      {
        UserPurchaseID = MoqDataGenerator.GetRandomNumber(1, 100)
      };

      // устанавливаем связи
      account.UserAccounts = new List<UserAccount> {userAccount};
      account.AccountPayments = new List<AccountPayment> {accountPayment};

      accountPayment.Payment = payment;
      accountPayment.Account = account;
      accountPayment.PaymentID = payment.PaymentID;
      accountPayment.AccountID = account.AccountID;

      payment.User = user;
      payment.AccountPayments = new List<AccountPayment> {accountPayment};
      payment.PurchasePayments = new List<PurchasePayment> {purchasePayment};
      payment.UserID = user.UserID;

      purchase.PurchasePayments = new List<PurchasePayment> {purchasePayment};
      purchase.UserPurchases = new List<UserPurchase> {userPurchase};

      purchasePayment.Payment = payment;
      purchasePayment.Purchase = purchase;
      purchasePayment.PaymentID = payment.PaymentID;
      purchasePayment.PurchaseID = purchase.PurchaseID;

      user.UserAccounts = new List<UserAccount> {userAccount};
      user.Payments = new List<Payment> {payment};
      user.UserPurchases = new List<UserPurchase> {userPurchase};

      userAccount.User = user;
      userAccount.Account = account;
      userAccount.UserID = user.UserID;
      userAccount.AccountID = account.AccountID;

      userPurchase.User = user;
      userPurchase.Purchase = purchase;
      userPurchase.UserID = user.UserID;
      userPurchase.PurchaseID = purchase.PurchaseID;

      await Accounts.AddAsync(account);
      await AccountPayments.AddAsync(accountPayment);
      await Payments.AddAsync(payment);
      await Purchases.AddAsync(purchase);
      await PurchasePayments.AddAsync(purchasePayment);
      await Users.AddAsync(user);
      await UserAccounts.AddAsync(userAccount);
      await UserPurchases.AddAsync(userPurchase);

    }
  }
}
