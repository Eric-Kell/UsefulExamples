using System.Collections.Generic;

namespace WebApplication.Models.Account
{
  public class CreateAccountInput
  {
    public string Name { get; set; }
    public IEnumerable<string> Logins { get; set; } 
  }
}
