using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Domain;
using Domain.Data;
using WebApplication.Models.Payment;

namespace WebApplication.Controllers
{
  public class PaymentController : ApiController
  {
    private IData data;
    private PaymentManager paymentManager;
    private UserManager userManager;
    private AccountManager accountManager;

    public PaymentController(IData d)
    {
      data = d;
      paymentManager = new PaymentManager(d);
      userManager = new UserManager(d);
      accountManager = new AccountManager(d);
    }

    [Route("api/payment/Add")]
    [HttpPost]
    public async Task AddPayment(AddPaymentInput model)
    {
      var userId = int.Parse(Request.Headers.GetValues("Token").First());
      var user = userManager.GetUserById(userId);
      var account = accountManager.GetAccountById(model.AccountId);
      await paymentManager.CreatePayment(model.Text, model.DateTime, user, account, model.Value);
    }
  }
}
