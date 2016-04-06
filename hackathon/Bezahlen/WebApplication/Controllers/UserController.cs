using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Domain;
using Domain.Data;
using Domain.Data.DB;
using WebApplication.Models.User;

namespace WebApplication.Controllers
{
  public class UserController : ApiController
  {
    private IData data;
    private UserManager manager;

    public UserController(IData d)
    {
      data = d;
      manager = new UserManager(d);
    }

    [Route("api/user/registration")]
    [HttpPost]
    public async Task<RegistrationOutput> Registration(RegistrationInput input)
    {
      var user = new User
      {
        Login = input.Login,
        Password = input.Password,
        Nickname = input.Nickname
      };
      await manager.AddUserAsync(user);
      var token = await manager.GetTokenForUserAsync(user);
      return new RegistrationOutput
      {
        Token = token,
        Login = user.Login
      };
    }

    [Route("api/user/entrance")]
    [HttpPost]
    public async Task<EntranceOutput> Entrance (EntranceInput input)
    {
      var user = manager.TryEnter(input.Login, input.Password);
      if (user == null)
      {
        throw new HttpResponseException(HttpStatusCode.NotFound);
      }
      var token = await manager.GetTokenForUserAsync(user);
      return new EntranceOutput
      {
        Token = token,
        Login = user.Login
      };
    }

  }
}
