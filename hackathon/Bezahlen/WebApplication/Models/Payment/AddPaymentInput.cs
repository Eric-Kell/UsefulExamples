using System;

namespace WebApplication.Models.Payment
{
  public class AddPaymentInput
  {
    public string Text { get; set; }
    public int AccountId { get; set; }
    public int Value { get; set; }
  }
}
