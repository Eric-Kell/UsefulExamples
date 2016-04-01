using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Data.DB;

namespace Domain
{
  public class UserManager
  {
    private IData data;

    public UserManager(IData d)
    {
      data = d;
    }

    public User TryEnter(string login, string password)
      => data.Users.Data.FirstOrDefault(x => x.Login == login && x.Password == password);

    public async Task AddUserAsync(User user)
      => await data.Users.AddAsync(user);
  }
}
