using System;
using System.Collections.Generic;

namespace WebApplication.Models.Account
{
  public class CreateAccountOutput
  {
    public int WalletId { get; set; }
    public string Name { get; set; }
    public int Balance { get; set; }
    public int TargetSum { get; set; }
    public int StartDay { get; set; }
    public IEnumerable<string> Logins { get; set; }
    public IEnumerable<string> Payments { get; set; } 
  }
}
