using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entities
{
  public class Purchase
  {
    public int PurchaseID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public virtual IEnumerable<PurchasePayment> PurchasePayments { get; set; }
    [JsonIgnore]
    public virtual IEnumerable<UserPurchase> UserPurchases { get; set; }
  }
}
