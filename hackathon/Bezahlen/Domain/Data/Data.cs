using Domain.Entities;
using Domain.Services;

namespace Domain.Data
{
  public class Data : Singleton<Data>, IData
  {
    private readonly DataContext _context = new DataContext();

    public IRepository<Account> Accounts { get; }
    public IRepository<AccountPayment> AccountPayments { get; }
    public IRepository<Payment> Payments { get; }
    public IRepository<Purchase> Purchases { get; }
    public IRepository<User> Users { get; }
    public IRepository<PurchasePayment> PurchasePayments { get; }
    public IRepository<UserAccount> UserAccounts { get; }
    public IRepository<UserPurchase> UserPurchases { get; }

    private Data()
    {
      Accounts = new EFRepository<Account>(_context, _context.Accounts);
      AccountPayments = new EFRepository<AccountPayment>(_context, _context.AccountPayments);
      Payments = new EFRepository<Payment>(_context, _context.Payments);
      Purchases = new EFRepository<Purchase>(_context, _context.Purchases);
      Users = new EFRepository<User>(_context, _context.Users);
      PurchasePayments = new EFRepository<PurchasePayment>(_context, _context.PurchasePayments);
      UserAccounts = new EFRepository<UserAccount>(_context, _context.UserAccounts);
      UserPurchases = new EFRepository<UserPurchase>(_context, _context.UserPurchases);
    }
  }
}
