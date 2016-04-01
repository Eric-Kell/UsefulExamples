using System;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Data.DB;

namespace Domain
{
  public class PaymentManager
  {
    private IData data;

    public PaymentManager(IData d)
    {
      data = d;
    }

    //public async Task<int> CreatePayment(string text, DateTime date, User user, Account account)
    //{
    //  var payment = new Payment
    //  {
    //    Date = date,
    //    Text = text,
    //    User = user
    //  };
    //}
  }
}
