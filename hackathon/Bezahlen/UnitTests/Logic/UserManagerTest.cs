using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Data;
using Domain.Data.DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Logic
{
  [TestClass]
  public class UserManagerTest : LogicTest
  {
    private UserManager userManager;

    public UserManagerTest()
    {
      userManager = new UserManager(data);
    }

    [TestMethod]
    public void TryEnterTest()
    {
      var user = data.Users.Data.First();
      var result = userManager.TryEnter(user.Login, user.Password);
      Assert.AreSame(user, result);
      result = userManager.TryEnter(user.Login, user.Password + MoqDataGenerator.GetRandomString(10));
      Assert.AreEqual(null, result);
    }

    [TestMethod]
    public async Task AddUserTest()
    {
      int amount = data.Users.Data.Count();
      var user = new User
      {
        Login = MoqDataGenerator.GetRandomString(10),
        Password = MoqDataGenerator.GetRandomString(10),
        Nickname = MoqDataGenerator.GetRandomString(10)
      };
      await userManager.AddUserAsync(user);
      Assert.AreEqual(amount + 1, data.Users.Data.Count());
      Assert.AreSame(user, data.Users.Data.Last());
    }

    [TestMethod]
    public async Task GetTokenForUserTest()
    {
      var amount = data.Tokens.Data.Count();
      var user = data.Users.Data.First();
      var result = await userManager.GetTokenForUserAsync(user);
      Assert.AreEqual(amount + 1, data.Tokens.Data.Count());
      Assert.AreNotEqual(null, result);
    }

    [TestMethod]
    public void GetUserByTokenTest()
    {
      var user = data.Users.Data.First();
      var token = data.Tokens.Data.First();
      var result = userManager.GetUserByToken(token.Value);
      Assert.AreSame(user, result);
    }
  }
}
