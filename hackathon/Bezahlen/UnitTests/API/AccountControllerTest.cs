using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using UnitTests.DB;
using WebApplication.Models.Account;
using WebApplication.Models.User;

namespace UnitTests.API
{
  [TestClass]
  public class AccountControllerTest : APITest
  {
    [TestMethod]
    public async Task CreateAccountTest()
    {
      var login = MoqDataGenerator.GetRandomString(10);
      var user = new User
      {
        Login = "привет"
      };
      context.Users.Add(user);
      await context.SaveChangesAsync();
      var amountUser = context.Users.Count();
      var amountUserAccount = context.UserAccounts.Count();
      //int accountId = 0;
      try
      {
        WebRequest request = WebRequest.Create(serverUrl + "/api/wallet/CreateWallet");
        CreateAccountInput input = new CreateAccountInput
        {
          Name = MoqDataGenerator.GetRandomString(10),
          Logins = new List<string> {user.Login}
        };
        var json = JsonConvert.SerializeObject(input);
        request.Method = "POST";
        byte[] byteArray = Encoding.UTF8.GetBytes(json);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        Stream dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();

        var responseData = JsonConvert.DeserializeObject<CreateAccountOutput>(responseFromServer);

        // todo написать потом

        //var data = new NameValueCollection();
        //data["Name"] = MoqDataGenerator.GetRandomString(10);
        //data["Logins"] = new List<string>() { user.Login};
        //data["Nickname"] = user.Nickname;
        //var response = wb.UploadValues(serverUrl + "/api/user/registration", "POST", data);
        //string json = Encoding.Default.GetString(response);
        //RegistrationOutput resp = JsonConvert.DeserializeObject<RegistrationOutput>(json);
        //Assert.AreEqual(amount + 1, context.Users.Count());

        //last = context.Users.ToList().Last();
        //Assert.AreEqual(last.Login, user.Login);
        //Assert.AreEqual(last.Password, user.Password);
        //Assert.AreEqual(last.Nickname, user.Nickname);
        //Assert.AreEqual(last.UserID, resp.Token);

      }
      finally
      {
        //context.Users.Remove(last);
        //await context.SaveChangesAsync();
        //Assert.AreEqual(amount, context.Users.Count());
      }
    }
  }
}
