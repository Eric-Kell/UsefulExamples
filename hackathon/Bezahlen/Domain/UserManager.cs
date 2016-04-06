using System;
using System.Diagnostics;
using System.Linq;
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

    public async Task<string> GetTokenForUserAsync(User user)
    {
      if (user.Tokens != null && user.Tokens.Any())
      {
        return user.Tokens.First().Value;
      }

      var value = Guid.NewGuid().ToString();

      if (data.Tokens.Data.Any())
      {
        while (data.Tokens.Data.Select(x => x.Value).Contains(value))
        {
          value = Guid.NewGuid().ToString();
        }
      }
      
      var token = new Token
      {
        User = user,
        Value = value
      };

      await data.Tokens.AddAsync(token);

      return value;
    }

    public User GetUserByToken(string val)
      => data.Tokens.Data.FirstOrDefault(x => x.Value == val)?.User;
  }
}
