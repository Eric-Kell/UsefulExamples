using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Domain;
using Domain.Data;
using WebApplication.Models.Account;

namespace WebApplication.Controllers
{
  public class AccountController : ApiController
  {
    private IData data;
    private AccountManager accountManager;
    private UserManager userManager;

    public AccountController(IData d)
    {
      data = d;
      accountManager = new AccountManager(d);
      userManager = new UserManager(d);
    }

    [Route("api/wallet/CreateWallet")]
    [HttpPost]
    public async Task<CreateAccountOutput> CreateAccount(CreateAccountInput model)
    {
      var userId = int.Parse(Request.Headers.GetValues("Token").First());
      var account = await accountManager.CreateAccount(model.Name);
      var logins = model.Logins.ToList();
      logins.Add(userManager.GetLoginById(userId));
      await accountManager.BindUserToAccountByLogins(account, logins);
      return new CreateAccountOutput
      {
        WalletId = account.AccountID
      };
    }

    [Route("api/wallet/AddUserToWallet")]
    [HttpPost]
    public async Task AddUserToAccount(AddUserToAccountInput model)
    {
      var account = accountManager.GetAccountById(model.AccountId);
      await accountManager.BindUserToAccountByLogins(account, new List<string> { model.Login});
    }

  }
}
