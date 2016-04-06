using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models.Account
{
  public class PaymentExport
  {
    public string Text { get; set; }
    public string  Date { get; set; }
    public int Value { get; set; }
    public string Login { get; set; }
  }
}
