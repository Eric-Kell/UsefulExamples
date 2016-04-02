using System;
using System.Collections.Generic;
using System.Linq;
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

    public async Task<int> CreatePayment(string text, DateTime date, User user, Account account, int value)
    {
      var payment = new Payment
      {
        Date = date,
        Text = text,
        User = user,
        Account = account,
        Value = value
      };
      await data.Payments.AddAsync(payment);
      return payment.PaymentID;
    }

    public IEnumerable<Payment> GetPaymentsByAccount(Account account)
      => data.Payments.Data.Where(x => x.Account == account);
  }
}
