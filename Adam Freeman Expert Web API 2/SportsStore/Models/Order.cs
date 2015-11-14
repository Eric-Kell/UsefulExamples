using System.Collections.Generic;

namespace SportsStore.Models
{
  public class Order
  {
    public int Id { get; set; }
    public string Customer { get; set; }
    public decimal TotalCost { get; set; }
    public ICollection<OrderLine> Lines { get; set; }
  }
}
