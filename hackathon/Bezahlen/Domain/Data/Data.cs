using Domain.Data.DB;
using Domain.Services;
using Account = Domain.Data.DB.Account;
using Payment = Domain.Data.DB.Payment;
using User = Domain.Data.DB.User;
using UserAccount = Domain.Data.DB.UserAccount;

namespace Domain.Data
{
  public class Data : Singleton<Data>, IData
  {
    private readonly Hac2112DBEntities1 _context = new Hac2112DBEntities1();

    public IRepository<Account> Accounts { get; }
    public IRepository<Payment> Payments { get; }
    public IRepository<User> Users { get; }
    public IRepository<UserAccount> UserAccounts { get; }
    public IRepository<Token> Tokens { get; } 

    private Data()
    {
      Accounts = new EFRepository<Account>(_context, _context.Accounts);
      Payments = new EFRepository<Payment>(_context, _context.Payments);
      Users = new EFRepository<User>(_context, _context.Users);
      UserAccounts = new EFRepository<UserAccount>(_context, _context.UserAccounts);
      Tokens = new EFRepository<Token>(_context, _context.Tokens);
    }
  }
}
