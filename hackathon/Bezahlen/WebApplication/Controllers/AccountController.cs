using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public async Task<HttpResponseMessage> CreateAccount(CreateAccountInput model)
    {
      var token = Request.Headers.GetValues("Token").First();
      var user = userManager.GetUserByToken(token);
      if (user == null)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, token);
      }

      var account = await accountManager.CreateAccount(model.Name, model.TargetSum);
      await accountManager.BindUserToAccountByUserId(account, user.UserID);

      return Request.CreateResponse(HttpStatusCode.OK, new CreateAccountOutput
      {
        WalletId = account.AccountID,
        Name = account.Name,
        Balance = 0,
        TargetSum = (int) account.TargetSum,
        StartDay = DateTime.Now.Day,
        Logins = new List<string>(),
        Payments = new List<Payment>()
      });
    }

    [Route("api/wallet/AddUserToWallet")]
    [HttpPost]
    public async Task<HttpResponseMessage> AddUserToAccount(AddUserToAccountInput model)
    {
      var token = Request.Headers.GetValues("Token").First();
      var user = userManager.GetUserByToken(token);
      if (user == null)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, token);
      }
      var account = accountManager.GetAccountById(model.WalletId);
      await accountManager.BindUserToAccountByUserId(account, user.UserID);

      var logins = accountManager.GetOwnersLogins(account).Where(x => x != user.Login);

      // get payments
      var payments = paymentManager.GetPaymentsByAccount(account).Select(x => new PaymentExport
      {
        //Date = MakeStr(x.Date),
        Date = x.Date.ToString("yyyy-MM-dd"),
        Text = x.Text,
        Login = x.User.Login,
        Value = Convert.ToInt32(x.Value)
      });

      // calc balance
      var balance = accountManager.GetUserBalance(user, account);

      return Request.CreateResponse(HttpStatusCode.OK, new AccountsExport
      {
        Balance = balance,
        Logins = logins,
        Name = account.Name,
        Payments = payments,
        StartDay = (int)account.StartDay,
        TargetSum = (int)account.TargetSum,
        WalletId = account.AccountID
      });

    }

    [Route("api/wallet/GetAllWallets")]
    [HttpGet]
    public  HttpResponseMessage GetAccounts()
    {
      // get user
      var token = Request.Headers.GetValues("Token").First();
      var user = userManager.GetUserByToken(token);
      if (user == null)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, token);
      }

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
          Date = x.Date.ToString("yyyy-MM-dd H:mm:ss"),
          Text = x.Text,
          Login = x.User.Login,
          Value = Convert.ToInt32(x.Value)
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

      return Request.CreateResponse(HttpStatusCode.OK, result);
    }

    [Route("api/wallet/RemoveSelfFromWallet")]
    [HttpPost]
    public async Task<HttpResponseMessage> RemoveSelfFromAccount(RemoveSelfFromAccountInput model)
    {
      var token = Request.Headers.GetValues("Token").First();
      var user = userManager.GetUserByToken(token);
      if (user == null)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, token);
      }

      var account = accountManager.GetAccountById(model.WalletId);
      await accountManager.RemoveUserFromAccount(user, account);
      return Request.CreateErrorResponse(HttpStatusCode.NoContent, "success");
    }

  }
}
