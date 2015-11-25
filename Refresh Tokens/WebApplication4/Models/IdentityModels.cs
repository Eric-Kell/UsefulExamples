using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace WebApplication4.Models
{
  // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
  public class ApplicationUser : IdentityUser
  {
    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager,
      string authenticationType)
    {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
      var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
      // Add custom user claims here
      return userIdentity;
    }
  }

  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext()
      : base("DefaultConnection", throwIfV1Schema: false)
    {
      Database.SetInitializer<ApplicationDbContext>(new
        StoreIdentityDbInitializer());
    }

    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
  }

  public class StoreIdentityDbInitializer :
    CreateDatabaseIfNotExists<ApplicationDbContext>
  {
    protected override void Seed(ApplicationDbContext context)
    {
      ApplicationUserManager userMgr =
        new ApplicationUserManager(new UserStore<ApplicationUser>(context));
      StoreRoleManager roleMgr =
        new StoreRoleManager(new RoleStore<StoreRole>(context));
      string roleName = "Administrators";
      string userName = "Admin";
      string password = "secret";
      string email = "admin@example.com";

      if (!roleMgr.RoleExists(roleName))
      {
        roleMgr.Create(new StoreRole(roleName));
      }

      ApplicationUser user = userMgr.FindByName(userName);
      if (user == null)
      {
        userMgr.Create(new ApplicationUser
        {
          UserName = userName,
          Email = email
        }, password);
        user = userMgr.FindByName(userName);
      }
      if (!userMgr.IsInRole(user.Id, roleName))
      {
        userMgr.AddToRole(user.Id, roleName);
      }
      base.Seed(context);
    }
  }
}