using System;
using System.Data.Entity;
using System.Linq;
using Domain.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.DB;
using Account = UnitTests.DB.Account;
using Payment = UnitTests.DB.Payment;
using User = UnitTests.DB.User;
using UserAccount = UnitTests.DB.UserAccount;

namespace UnitTests
{
  [TestClass]
  public class DataBaseTest
  {
    private readonly Hac2112DBEntities1 _context = new Hac2112DBEntities1();

    // создадим тестовые данные

    private User user = new User
    {
      Login = MoqDataGenerator.GetRandomString(10),
      Password = MoqDataGenerator.GetRandomString(10),
      Nickname = MoqDataGenerator.GetRandomString(10),
      UserID = MoqDataGenerator.GetRandomNumber(1, 100)
    };

    private Account account = new Account
    {
      AccountID = MoqDataGenerator.GetRandomNumber(1, 100),
      Name = MoqDataGenerator.GetRandomString(10),
      Description = MoqDataGenerator.GetRandomString(100)
    };

    private Payment payment = new Payment
    {
      Date = DateTime.Now,
      PaymentID = MoqDataGenerator.GetRandomNumber(1, 100),
      Value = MoqDataGenerator.GetRandomNumber(1, 1000),
      Text = MoqDataGenerator.GetRandomString(1000)
    };

    private UserAccount userAccount = new UserAccount
    {
      UserAccountID = MoqDataGenerator.GetRandomNumber(1, 100)
    };

    private int _amountUsersWas;
    private int _amountAccountPaymentsWas;
    private int _amountAccountsWas;
    private int _amountPaymentsWas;
    private int _amountPurchasesWas;
    private int _amountPurchasePaymentsWas;
    private int _amountUserAccountsWas;
    private int _amountUserPurchasesWas;


    [TestMethod]
    public void TestCRUD()
    {
      /*
      Сценарий:
        CREATE:
          0. Сущности уже созданы с тестовыми данными.
          1. Устанавливаем связи между сущностями
          2. Запоминаем количество каждой из сущностей
          3. Сохраняем сущности в БД.
          4. проверить, что наши экземпляры сущностей лежат в БД
          5. Проверяем количества 
          6. Проверяем связи
        UPDATE:
          7. поменяем все кроме ImageRecipe, ибо такие нужно не менять, а удалять
          8. сохраним изменения в БД
          9. проверить, что наши экземпляры сущностей по-прежнему лежат в БД
        REMOVE:
          10. запомним Id сущностей
          11. удалим из бд
          12. проверим количества 
          13. проверим, что таких сущностей теперь нету
      */

      CheckCreateData();
      CheckUpdateData();
      CheckRemoveData();
    }

    private void CheckCreateData()
    {
      // установим связи
      payment.User = user;
      userAccount.User = user;
      userAccount.Account = account;
      payment.Account = account;

      // запомним текущие количества
      _amountUsersWas = _context.Users.Count();
      _amountAccountsWas = _context.Accounts.Count();
      _amountPaymentsWas = _context.Payments.Count();
      _amountUserAccountsWas = _context.UserAccounts.Count();

      // добавим в бд
      _context.Users.Add(user);
      _context.Accounts.Add(account);
      _context.Payments.Add(payment);
      _context.UserAccounts.Add(userAccount);

      _context.SaveChanges();
      // проверим количества
      Assert.AreEqual(_amountUsersWas + 1, _context.Users.Count());
      Assert.AreEqual(_amountAccountsWas + 1, _context.Accounts.Count());
      Assert.AreEqual(_amountPaymentsWas + 1, _context.Payments.Count());
      Assert.AreEqual(_amountUserAccountsWas + 1, _context.UserAccounts.Count());
      // проверить, что наши экземпляры сущностей лежат в БД
      CheckEntitiesAreInDB();
    }

    private void CheckUpdateData()
    {
      // поменяем
      user.Login = MoqDataGenerator.GetRandomString(10);
      user.Password = MoqDataGenerator.GetRandomString(10);
      user.Nickname = MoqDataGenerator.GetRandomString(10);
      account.Description = MoqDataGenerator.GetRandomString(10);
      account.Name = MoqDataGenerator.GetRandomString(10);
      payment.Date = DateTime.Now;
      payment.Text = MoqDataGenerator.GetRandomString(10);
      payment.Value = MoqDataGenerator.GetRandomNumber(1, 100);

      // сохраним изменения в БД
      _context.Entry(user).State = EntityState.Modified;
      _context.Entry(account).State = EntityState.Modified;
      _context.Entry(payment).State = EntityState.Modified;
      _context.SaveChanges();

      // проверить, что наши экземпляры сущностей по-прежнему лежат в БД
      CheckEntitiesAreInDB();
    }

    private void CheckRemoveData()
    {
      // запомним Id сущностей
      int userId = user.UserID;
      int accountId = account.AccountID;
      int paymentId = payment.PaymentID;
      int userAccountId = userAccount.UserAccountID;

      // удалим из бд (каскадно)
      _context.Users.Remove(user);
      _context.Accounts.Remove(account);
      _context.SaveChanges();

      // проверим количества
      Assert.AreEqual(_amountUsersWas, _context.Users.Count());
      Assert.AreEqual(_amountAccountsWas, _context.Accounts.Count());
      Assert.AreEqual(_amountPaymentsWas, _context.Payments.Count());
      Assert.AreEqual(_amountUserAccountsWas, _context.UserAccounts.Count());

      // проверим, что таких сущностей теперь нету
      Assert.AreEqual(null, _context.Users.FirstOrDefault(x => x.UserID == userId));
      Assert.AreEqual(null, _context.Accounts.FirstOrDefault(x => x.AccountID == accountId));
      Assert.AreEqual(null, _context.Payments.FirstOrDefault(x => x.PaymentID == paymentId));
      Assert.AreEqual(null, _context.UserAccounts.FirstOrDefault(x => x.UserAccountID == userAccountId));
    }

    private void CheckEntitiesAreInDB()
    {
      Assert.AreSame(user, _context.Users.First(x => x.UserID == user.UserID));
      Assert.AreSame(account, _context.Accounts.First(x => x.AccountID == account.AccountID));
      Assert.AreSame(payment, _context.Payments.First(x => x.PaymentID == payment.PaymentID));
      Assert.AreSame(userAccount, _context.UserAccounts.First(x => x.UserAccountID == userAccount.UserAccountID));
    }
  }
}