using BankingSystem.Domain.Entities.Account.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infra.Data.FluentConfigs.Account.Customer
{
	public class OpenAccountConfig : IEntityTypeConfiguration<Domain.Entities.Account.Customer.OpenAccount>
	{
		public void Configure(EntityTypeBuilder<OpenAccount> builder)
		{
			builder.HasKey(o => o.OpenAccountId);
			builder.Property(o => o.AccountNumber).IsRequired().HasMaxLength(20);
			builder.Property(o => o.CardNumber).IsRequired().HasMaxLength(20);
			builder.Property(o => o.ExpDate).IsRequired();
			builder.Property(o => o.Cvv2).IsRequired();
			builder.Property(o => o.Shaba).IsRequired().HasMaxLength(40);
			builder.Property(o => o.CardPassword).IsRequired();

			builder.HasOne(o => o.Deposit).WithMany(o => o.OpenAccounts).HasForeignKey(o => o.DepositId);
			builder.HasOne(o => o.Branch).WithMany(o => o.OpenAccounts).HasForeignKey(o => o.BranchId);

		}
	}
}
