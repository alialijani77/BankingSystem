using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Domain.Entities.Account.User;
using BankingSystem.Domain.Entities.Branch;
using BankingSystem.Domain.Entities.Common;
using BankingSystem.Domain.Entities.Deposit;
using BankingSystem.Infra.Data.FluentConfigs.Account.Customer;
using BankingSystem.Infra.Data.FluentConfigs.Account.User;
using BankingSystem.Infra.Data.FluentConfigs.Branch;
using BankingSystem.Infra.Data.FluentConfigs.Deposit;
using Microsoft.EntityFrameworkCore;
using BankingSystem.Domain.Entities.Transaction;
using BankingSystem.Infra.Data.FluentConfigs.Transaction;

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

		public DbSet<Permission> Permissions { get; set; }

		public DbSet<Branch> Branches { get; set; }

		public DbSet<UserProfile> UserProfiles { get; set; }

		public DbSet<User> Users { get; set; }

        public DbSet<UserKeyValue> UserKeyValues { get; set; }

		public DbSet<UserProfileKeyValue> UserProfileKeyValues { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Deposit> Deposits { get; set; }

		public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new CustomerConfig());

			modelBuilder.ApplyConfiguration(new OpenAccountConfig());

			modelBuilder.ApplyConfiguration(new UserProfileConfig());

			modelBuilder.ApplyConfiguration(new UserConfig());

			modelBuilder.ApplyConfiguration(new BranchConfig());

			modelBuilder.ApplyConfiguration(new DepositConfig());

			modelBuilder.ApplyConfiguration(new UserKeyValueConfig());

			modelBuilder.ApplyConfiguration(new UserProfileKeyValueConfig());

			modelBuilder.ApplyConfiguration(new StateConfig());

			modelBuilder.ApplyConfiguration(new PermissionConfig());

			modelBuilder.ApplyConfiguration(new TransactionConfig());
		}
	}
}
