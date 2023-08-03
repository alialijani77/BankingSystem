using BankingSystem.Domain.Entities.Account.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infra.Data.FluentConfigs.Account.Customer
{
	public class OpenAccountConfig : IEntityTypeConfiguration<Domain.Entities.Account.Customer.OpenAccount>
	{
		public void Configure(EntityTypeBuilder<OpenAccount> builder)
		{
			builder.HasKey(o => o.OpenAccountId);
			builder.Property(o => o.AccountNumber).IsRequired().HasMaxLength(30);
			builder.Property(o => o.CardNumber).IsRequired().HasMaxLength(16);
			builder.Property(o => o.Expmonth).IsRequired();
			builder.Property(o => o.ExpYear).IsRequired();
			builder.Property(o => o.Cvv2).IsRequired();
			builder.Property(o => o.Shaba).IsRequired().HasMaxLength(40);
			builder.Property(o => o.CardPassword).IsRequired();
			builder.Property(o => o.DepositFacilityPoints).HasDefaultValue(0);
			builder.Property(o => o.DepositLotteryPoints).HasDefaultValue(0);
			builder.Property(o => o.WithdrawToAccountCount).HasDefaultValue(0);
			builder.Property(o => o.DepositToAccountCount).HasDefaultValue(0);
			builder.Property(o => o.Otp).HasDefaultValue(0);
			builder.HasOne(o => o.Deposit).WithMany(o => o.OpenAccounts).HasForeignKey("DepositId").HasConstraintName("DepositId");
			builder.HasOne(o => o.Branch).WithMany(o => o.OpenAccounts).HasForeignKey("BranchId").HasConstraintName("BranchId");
			builder.HasOne(o => o.Customer).WithMany(o => o.OpenAccounts).HasForeignKey("CustomerId").HasConstraintName("CustomerId");

		}
	}
}
