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
    private AccountManager manager;

    public AccountController(IData d)
    {
      data = d;
      manager = new AccountManager(d);
    }

    [Route("api/wallet/CreateWallet")]
    [HttpPost]
    public async Task<CreateAccountOutput> CreateAccount(CreateAccountInput model)
    {

      var account = await manager.CreateAccount(model.Name);
      await manager.BindUserToAccountByLogins(account, model.Logins.ToList());
      return new CreateAccountOutput
      {
        WalletId = account.AccountID
      };
    }

  }
}
