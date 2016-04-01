using System.Collections.Generic;

namespace Domain.Entities
{
  public class User
  {
    public int UserID { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Nickname { get; set; }
    public virtual IEnumerable<Payment> Payments { get; set; }
    public virtual IEnumerable<UserAccount> UserAccounts { get; set; }
    public virtual IEnumerable<UserPurchase> UserPurchases { get; set; }
  }
}
