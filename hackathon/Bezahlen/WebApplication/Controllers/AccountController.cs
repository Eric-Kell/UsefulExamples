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
      var account = await accountManager.CreateAccount(model.Name, model.TargetSum);
      await accountManager.BindUserToAccountByUserId(account, userId);
      return new CreateAccountOutput
      {
        WalletId = account.AccountID
      };
    }

    //[Route("api/wallet/AddUserToWallet")]
    //[HttpPost]
    //public async Task AddUserToAccount(AddUserToAccountInput model)
    //{
    //  var userId = int.Parse(Request.Headers.GetValues("Token").First());
    //  var account = accountManager.GetAccountById(model.AccountId);
    //  await accountManager.BindUserToAccountByUserId(account, new List<string> { model.Login });
    //}

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
