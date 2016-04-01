using Domain.Data.DB;
using Domain.Services;
using Account = Domain.Data.DB.Account;
using AccountPayment = Domain.Data.DB.AccountPayment;
using Payment = Domain.Data.DB.Payment;
using Purchase = Domain.Data.DB.Purchase;
using PurchasePayment = Domain.Data.DB.PurchasePayment;
using User = Domain.Data.DB.User;
using UserAccount = Domain.Data.DB.UserAccount;
using UserPurchase = Domain.Data.DB.UserPurchas;

namespace Domain.Data
{
  public class Data : Singleton<Data>, IData
  {
    private readonly Hac2112DBEntities _context = new Hac2112DBEntities();

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
