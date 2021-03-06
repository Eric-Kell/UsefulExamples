﻿using System.Data.Entity;
using Domain.Entities;

namespace WebApplication.Models.Data
{
  public class DataContext : DbContext
  {
    public DbSet<Account> Accounts { get; }
    public DbSet<AccountPayment> AccountPayments { get; }
    public DbSet<Payment> Payments { get; }
    public DbSet<Purchase> Purchases { get; }
    public DbSet<Domain.Entities.User> Users { get; }
    public DbSet<PurchasePayment> PurchasePayments { get; }
    public DbSet<UserAccount> UserAccounts { get; }
    public DbSet<UserPurchase> UserPurchases { get; }
  }
}
