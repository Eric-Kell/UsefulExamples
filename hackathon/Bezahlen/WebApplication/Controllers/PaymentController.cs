using System;
using System.Linq;
using System.Net;
using System.Net.Http;
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

    [System.Web.Http.Route("api/payment/Add")]
    [System.Web.Http.HttpPost]
    public async Task<HttpResponseMessage> AddPayment(AddPaymentInput model)
    {
      var token = Request.Headers.GetValues("Token").First();
      var user = userManager.GetUserByToken(token);
      if (user == null)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, token);
      }
      var account = accountManager.GetAccountById(model.AccountId);
      await paymentManager.CreatePayment(model.Text, DateTime.Now, user, account, model.Value);
      return Request.CreateErrorResponse(HttpStatusCode.NoContent, "success");
    }
  }
}
