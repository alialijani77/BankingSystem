using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Domain.Entities.Account.User;
using BankingSystem.Domain.Entities.Branch;
using BankingSystem.Domain.Entities.Deposit;
using BankingSystem.Infra.Data.FluentConfigs.Account.Customer;
using BankingSystem.Infra.Data.FluentConfigs.Account.User;
using BankingSystem.Infra.Data.FluentConfigs.Branch;
using BankingSystem.Infra.Data.FluentConfigs.Deposit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infra.Data.Context
{
	public class BankingSystemDbContext : DbContext
	{
		#region ctor
		public BankingSystemDbContext(DbContextOptions<BankingSystemDbContext> options) : base(options)
		{
		}
		#endregion

		public DbSet<Customer> Customers { get; set; }

		public DbSet<OpenAccount> OpenAccounts { get; set; }

		public DbSet<OpenAccountCustomer> OpenAccountCustomers { get; set; }

		public DbSet<Permission> Permissions { get; set; }

		public DbSet<Branch> Branches { get; set; }


		public DbSet<User> Users { get; set; }

		public DbSet<Deposit> Deposits { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new CustomerConfig());

			modelBuilder.ApplyConfiguration(new OpenAccountConfig());

			modelBuilder.ApplyConfiguration(new OpenAccountCustomerConfig());

			modelBuilder.ApplyConfiguration(new UserConfig());

			modelBuilder.ApplyConfiguration(new BranchConfig());

			modelBuilder.ApplyConfiguration(new DepositConfig());

		}
	}
}
