using Domain.Data.DB;

namespace Domain.Data
{
  public interface IData
  {
    IRepository<Account> Accounts { get; }
    IRepository<Payment> Payments { get; }
    IRepository<User> Users { get; }
    IRepository<UserAccount> UserAccounts { get; }
  }
}