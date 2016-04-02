using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models.Account
{
  public class AccountsExport
  {
    public int WalletId { get; set; }
    public string Name { get; set; }
    public int Balance { get; set; }
    public int TargetSum { get; set; }
    public int StartDay { get; set; }
    public IEnumerable<string> Logins { get; set; }
    public IEnumerable<PaymentExport> Payments { get; set; }
  }
}
