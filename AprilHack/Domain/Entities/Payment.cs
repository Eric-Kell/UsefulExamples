using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entities
{
  public class Payment
  {
    public int PaymentID { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public int UserID { get; set; }
    [JsonIgnore]
    public virtual User User { get; set; }
    [JsonIgnore]
    public virtual IEnumerable<PurchasePayment> PurchasePayments { get; set; }
    [JsonIgnore]
    public virtual IEnumerable<AccountPayment> AccountPayments { get; set; }
  }
}
