using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using UnitTests.DB;
using WebApplication.Models.User;

namespace UnitTests.API
{
  [TestClass]
  public class UserControllerTest : APITest
  {
    [TestMethod]
    public async Task RegistrationTest()
    {
      User last = null;
      var amount = context.Users.Count();
      try
      {
        using (var wb = new WebClient())
        {
          wb.Encoding = Encoding.UTF8;
          var data = new NameValueCollection();
          var user = new User
          {
            Login = MoqDataGenerator.GetRandomString(10),
            Password = MoqDataGenerator.GetRandomString(10),
            Nickname = MoqDataGenerator.GetRandomString(10),
          };
          data["Login"] = user.Login;
          data["Password"] = user.Password;
          data["Nickname"] = user.Nickname;
          var response = wb.UploadValues(serverUrl + "/api/user/registration", "POST", data);
          string json = Encoding.Default.GetString(response);
          RegistrationOutput resp = JsonConvert.DeserializeObject<RegistrationOutput>(json);
          Assert.AreEqual(amount + 1, context.Users.Count());

          last = context.Users.ToList().Last();
          Assert.AreEqual(last.Login, user.Login);
          Assert.AreEqual(last.Password, user.Password);
          Assert.AreEqual(last.Nickname, user.Nickname);
          Assert.AreEqual(last.UserID, resp.Token);
        }
      }
      finally
      {
        context.Users.Remove(last);
        await context.SaveChangesAsync();
        Assert.AreEqual(amount, context.Users.Count());
      }
    }

    [TestMethod]
    public async Task EntranceTest()
    {
      var amount = context.Users.Count();
      var user = new User
      {
        Login = MoqDataGenerator.GetRandomString(10),
        Password = MoqDataGenerator.GetRandomString(10),
      };
      context.Users.Add(user);
      await context.SaveChangesAsync();
      try
      {
        using (var wb = new WebClient())
        {
          // хороший случай
          wb.Encoding = Encoding.UTF8;
          var data = new NameValueCollection();
          data["Login"] = user.Login;
          data["Password"] = user.Password;
          var response = wb.UploadValues(serverUrl + "/api/user/entrance", "POST", data);
          string json = Encoding.Default.GetString(response);
          EntranceOutput resp = JsonConvert.DeserializeObject<EntranceOutput>(json);
          Assert.AreEqual(resp.Token, user.UserID);

          // плохой случай
          bool failed = false;
          data["Login"] = user.Login + MoqDataGenerator.GetRandomString(10);
          data["Password"] = user.Password;
          try
          {
            response = wb.UploadValues(serverUrl + "/api/user/entrance", "POST", data);
          }
          catch (Exception e)
          {

            failed = true;
          }
          Assert.AreEqual(failed, true);
        }
      }
      finally
      {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        Assert.AreEqual(amount, context.Users.Count());
      }
    }
  }
}
