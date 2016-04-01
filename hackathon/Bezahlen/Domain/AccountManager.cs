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

    public async Task<Account> CreateAccount( string name)
    {
      var account = new Account
      {
        Name = name
      };
      await data.Accounts.AddAsync(account);
      return account;
    }

    public async Task BindUserToAccountByLogins(Account account, List<string> logins)
    {
      foreach (var userAccount in logins.
        Select(login => data.Users.Data.First(x => x.Login == login)).
        Select(user => new UserAccount
        {
          Account = account,
          User = user
        }))
      {
        await data.UserAccounts.AddAsync(userAccount);
      }
    }

    public Account GetAccountById(int id)
      => data.Accounts.Data.First(x => x.AccountID == id);
  }
}
