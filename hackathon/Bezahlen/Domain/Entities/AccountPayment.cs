using Newtonsoft.Json;

namespace Domain.Entities
{
  public class AccountPayment
  {
    public int AccountPaymentID { get; set; }
    public int AccountID { get; set; }
    public int PaymentID { get; set; }
    [JsonIgnore]
    public virtual Payment Payment { get; set; }
    [JsonIgnore]
    public virtual Account Account { get; set; }
  }
}
