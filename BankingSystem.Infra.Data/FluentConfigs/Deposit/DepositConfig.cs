using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infra.Data.FluentConfigs.Deposit
{
	public class DepositConfig : IEntityTypeConfiguration<Domain.Entities.Deposit.Deposit>
	{
		public void Configure(EntityTypeBuilder<Domain.Entities.Deposit.Deposit> builder)
		{
			builder.HasKey(d => d.DepositId);
			builder.Property(d => d.DepositName).IsRequired().HasMaxLength(100);
			builder.Property(d => d.DepositInterestRate).IsRequired();
			builder.Property(d => d.DepositDailyPointsRate).IsRequired().HasDefaultValue(0);
			builder.Property(d => d.DepositFacilityPointsRate).IsRequired().HasDefaultValue(0);
			builder.Property(d => d.CreateUserId).IsRequired();

		}
	}
}
