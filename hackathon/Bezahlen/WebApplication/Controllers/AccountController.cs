﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Domain;
using Domain.Data;
using WebApplication.Models.Account;

namespace WebApplication.Controllers
{
  public class AccountController : ApiController
  {
    private IData data;
    private AccountManager accountManager;
    private UserManager userManager;

    public AccountController(IData d)
    {
      data = d;
      accountManager = new AccountManager(d);
      userManager = new UserManager(d);
    }

    [Route("api/wallet/CreateWallet")]
    [HttpPost]
    public async Task<CreateAccountOutput> CreateAccount(CreateAccountInput model)
    {
      var userId = int.Parse(Request.Headers.GetValues("Token").First());
      var account = await accountManager.CreateAccount(model.Name, model.TargetSum);
      await accountManager.BindUserToAccountByUserId(account, userId);
      return new CreateAccountOutput
      {
        WalletId = account.AccountID,
        Name = account.Name,
        Balance = 0,
        TargetSum = (int) account.TargetSum,
        StartDay = DateTime.Now.Day,
        Logins = new List<string>(),
        Payments = new List<string>()
      };
    }

    [Route("api/wallet/AddUserToWallet")]
    [HttpPost]
    public async Task AddUserToAccount(AddUserToAccountInput model)
    {
      var userId = int.Parse(Request.Headers.GetValues("Token").First());
      var account = accountManager.GetAccountById(model.WalletId);
      await accountManager.BindUserToAccountByUserId(account, userId);
    }

  }
}
