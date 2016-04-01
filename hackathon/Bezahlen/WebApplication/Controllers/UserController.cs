﻿using System.Net;
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
      return new RegistrationOutput
      {
        Token = user.UserID
      };
    }

    [Route("api/user/entrance")]
    [HttpPost]
    public EntranceOutput Entrance (EntranceInput input)
    {
      var user = manager.TryEnter(input.Login, input.Password);
      if (user == null)
      {
        throw new HttpResponseException(HttpStatusCode.NotFound);
      }
      return new EntranceOutput
      {
        Token = user.UserID
      };
    }

  }
}
