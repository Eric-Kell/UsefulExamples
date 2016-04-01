using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models.Payment
{
  public class AddPaymentInput
  {
    public string Text { get; set; }
    public DateTime DateTime { get; set; }
    public int AccountId { get; set; }
  }
}
