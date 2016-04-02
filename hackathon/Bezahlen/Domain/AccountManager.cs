using System.Collections.Generic;
using System.Linq;
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
        TargetSum = sum
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

  }
}
