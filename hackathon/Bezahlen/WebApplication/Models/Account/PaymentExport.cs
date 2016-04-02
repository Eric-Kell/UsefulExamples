using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models.Account
{
  public class PaymentExport
  {
    public int PaymentID { get; set; }
    public string Text { get; set; }
    public System.DateTime Date { get; set; }
    public decimal Value { get; set; }
    public int UserID { get; set; }
    public int AccountID { get; set; }
  }
}
