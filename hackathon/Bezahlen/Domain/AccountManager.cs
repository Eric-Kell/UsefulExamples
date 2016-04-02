using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Data.DB;

namespace Domain
{
  public class AccountManager
  {
    private IData data;

    public AccountManager(IData d)
    {
      data = d;
    }

    public async Task<Account> CreateAccount( string name, int sum)
    {
      var account = new Account
      {
        Name = name,
        TargetSum = sum,
        StartDay = DateTime.Now.Day
      };
      await data.Accounts.AddAsync(account);
      return account;
    }

    public async Task BindUserToAccountByUserId(Account account, int userId)
    {
      var user = data.Users.Data.First(x => x.UserID == userId);
      var userAccount = new UserAccount
      {
        Account = account,
        User = user
      };
      await data.UserAccounts.AddAsync(userAccount);
    }

    public Account GetAccountById(int id)
      => data.Accounts.Data.First(x => x.AccountID == id);

    public IEnumerable<Account> GetUserAccounts(User user)
      => data.UserAccounts.Data.Where(x => x.User == user).Select(x => x.Account);

    public List<string> GetOwnersLogins(Account account)
     => data.UserAccounts.Data.Where(x => x.Account == account).Select(x => x.User.Login).ToList();

    public int GetUserBalance(User user, Account account)
    {
      decimal allSum = data.Payments.Data.Where(x => x.Account == account).Sum(payment => payment.Value);
      decimal userSum = data.Payments.Data.Where(x => x.Account == account && x.User == user).Sum(payment => payment.Value);
      int amountUsers = data.UserAccounts.Data.Where(x => x.Account == account).Select(x => x.User).Count();
      return (int) ((double) userSum - (double) allSum/ amountUsers);
    }
    

  }
}
