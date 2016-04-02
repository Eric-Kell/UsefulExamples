using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Domain;
using Domain.Data;
using Domain.Data.DB;
using WebApplication.Models.Account;

namespace WebApplication.Controllers
{
  public class AccountController : ApiController
  {
    private IData data;
    private AccountManager accountManager;
    private UserManager userManager;
    private PaymentManager paymentManager;

    public AccountController(IData d)
    {
      data = d;
      accountManager = new AccountManager(d);
      userManager = new UserManager(d);
      paymentManager = new PaymentManager(d);
    }

    [Route("api/wallet/CreateWallet")]
    [HttpPost]
    public async Task<CreateAccountOutput> CreateAccount(CreateAccountInput model)
    {
      var userId = int.Parse(Request.Headers.GetValues("Token").First());
      var account = await accountManager.CreateAccount(model.Name, model.TargetSum);
      await accountManager.BindUserToAccountByUserId(account, userId);
      return new CreateAccountOutput
      {
        WalletId = account.AccountID,
        Name = account.Name,
        Balance = 0,
        TargetSum = (int) account.TargetSum,
        StartDay = DateTime.Now.Day,
        Logins = new List<string>(),
        Payments = new List<Payment>()
      };
    }

    [Route("api/wallet/AddUserToWallet")]
    [HttpPost]
    public async Task AddUserToAccount(AddUserToAccountInput model)
    {
      var userId = int.Parse(Request.Headers.GetValues("Token").First());
      var account = accountManager.GetAccountById(model.WalletId);
      await accountManager.BindUserToAccountByUserId(account, userId);
    }

    [Route("api/wallet/GetAllWallets")]
    [HttpGet]
    public  IEnumerable<AccountsExport> GetAccounts()
    {
      // get user
      var userId = int.Parse(Request.Headers.GetValues("Token").First());
      var user = userManager.GetUserById(userId);

      // get user accounts
      var accounts = accountManager.GetUserAccounts(user);

      var result = new List<AccountsExport>();

      foreach (var account in accounts)
      {
        //get login
        var logins = accountManager.GetOwnersLogins(account).Where(x => x != user.Login);

        // get payments
        var payments = paymentManager.GetPaymentsByAccount(account).Select(x => new PaymentExport
        {
          AccountID = x.AccountID,
          Date = x.Date,
          PaymentID = x.PaymentID,
          Text = x.Text,
          UserID = x.UserID,
          Value = x.Value
        });

        // calc balance
        var balance = accountManager.GetUserBalance(user, account);

        result.Add(new AccountsExport
        {
          Balance = balance,
          Logins = logins,
          Name = account.Name,
          Payments = payments,
          StartDay = (int) account.StartDay,
          TargetSum = (int) account.TargetSum,
          WalletId = account.AccountID
        });
      }
      return result;
    }

    [Route("api/wallet/RemoveSelfFromWallet")]
    [HttpPost]
    public async Task RemoveSelfFromAccount(RemoveSelfFromAccountInput model)
    {
      var userId = int.Parse(Request.Headers.GetValues("Token").First());
      var user = userManager.GetUserById(userId);
      var account = accountManager.GetAccountById(model.AccountId);
      await accountManager.RemoveUserFromAccount(user, account);
    }

  }
}
