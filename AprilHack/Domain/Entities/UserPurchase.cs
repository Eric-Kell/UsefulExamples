using Newtonsoft.Json;

namespace Domain.Entities
{
  public class UserPurchase
  {
    public int UserPurchaseID { get; set; }
    public int PurchaseID { get; set; }
    public int UserID { get; set; }
    [JsonIgnore]
    public virtual User User { get; set; }
    [JsonIgnore]
    public virtual Purchase Purchase { get; set; }
  }
}
