using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entities
{
  public class Account
  {
    public int AccountID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public virtual IEnumerable<AccountPayment> AccountPayments { get; set; }
    [JsonIgnore]
    public virtual IEnumerable<UserAccount> UserAccounts { get; set; }
  }
}
