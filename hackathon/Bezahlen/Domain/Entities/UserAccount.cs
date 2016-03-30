using Newtonsoft.Json;

namespace Domain.Entities
{
  public class UserAccount
  {
    public int UserAccountID { get; set; }
    public int UserID { get; set; }
    public int AccountID { get; set; }
    [JsonIgnore]
    public virtual User User { get; set; }
    [JsonIgnore]
    public virtual Account Account { get; set; }

  }
}
