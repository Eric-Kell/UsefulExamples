using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
  //[Authorize(Roles = "Administrators")]
  [Authorize]
  public class ValuesController : ApiController
  {
    // GET api/values
    public async Task<IEnumerable<string>> Get()
    {
      // Именно тут я нафигачу 3 свои проверки


      
      ApplicationDbContext context = new ApplicationDbContext();
      ApplicationUserManager userMgr =
        new ApplicationUserManager(new UserStore<ApplicationUser>(context));
      StoreRoleManager roleMgr =
        new StoreRoleManager(new RoleStore<StoreRole>(context));

      //var id = HttpContext.Current.User.Identity.GetUserId();

      //userMgr.UpdateSecurityStamp(id);

      // create
      //string roleName = "Administrators";
      //string userName = "Admin";
      //string password = "secret";
      //string email = "admin@example.com";
      //roleMgr.Create(new StoreRole(roleName));
      //userMgr.Create(new ApplicationUser
      //{
      //  UserName = userName,
      //  Email = email
      //}, password);
      //ApplicationUser user = userMgr.FindByName(userName);
      //userMgr.AddToRole(user.Id, roleName);

      //// просто обновить что-то
      //ApplicationUser user = context.Users.First(x => x.UserName == "Admin");
      //user.UserName = "Admin2";
      //userMgr.Update(user);

      //// сменить пароль - тупо, но работает
      //ApplicationUser user = context.Users.First(x => x.UserName == "Admin2");
      //string pas = "djkool";
      //ApplicationUser cUser = userMgr.FindById(user.Id);
      //await userMgr.RemovePasswordAsync(user.Id);
      //userMgr.AddPassword(user.Id, pas);


      return new string[] {"value1", "value2"};
    }

    [AllowAnonymous]
    // GET api/values/5
    public async Task<IHttpActionResult> Get(int id)
    {
      AuthRepository repo = new AuthRepository();
      var result = await repo.RemoveRefreshToken("tY9ObC8FxTOOSh/XQmieQ0a2AYm9FjqzubnRCLvuIYU=");
      if (result)
      {
        return Ok();
      }
      return BadRequest("Token Id does not exist");
    }


    // POST api/values
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    public void Put(int id, [FromBody] string value)
    {
    }
  }
}
