using Newtonsoft.Json;

namespace Domain.Entities
{
  public class PurchasePayment
  {
    public int PurchasePaymentID { get; set; }
    public int PurchaseID { get; set; }
    public int PaymentID { get; set; }
    [JsonIgnore]
    public virtual Purchase Purchase { get; set; }
    [JsonIgnore]
    public virtual Payment Payment { get; set; }
  }
}
