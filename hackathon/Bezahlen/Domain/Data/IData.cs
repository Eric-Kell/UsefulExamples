using Domain.Entities;

namespace Domain.Data
{
  public interface IData
  {
    IRepository<Account> Accounts { get; }
    IRepository<AccountPayment> AccountPayments { get; }
    IRepository<Payment> Payments { get; }
    IRepository<Purchase> Purchases { get; }
    IRepository<User> Users { get; }
    IRepository<PurchasePayment> PurchasePayments { get; }
    IRepository<UserAccount> UserAccounts { get; }
    IRepository<UserPurchase> UserPurchases { get; }
  }
}