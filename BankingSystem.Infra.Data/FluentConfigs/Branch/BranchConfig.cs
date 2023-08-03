using Microsoft.EntityFrameworkCore;


namespace BankingSystem.Infra.Data.FluentConfigs.Branch
{
	public class BranchConfig : IEntityTypeConfiguration<BankingSystem.Domain.Entities.Branch.Branch>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BankingSystem.Domain.Entities.Branch.Branch> builder)
		{
			builder.HasKey(b => b.BranchId);
			builder.Property(b => b.BranchName).IsRequired().HasMaxLength(50);
			builder.Property(b => b.BranchCode).IsRequired().HasMaxLength(4);
			builder.Property(b => b.Address).IsRequired().HasMaxLength(250);
			builder.Property(b => b.CreateUserId).IsRequired();
			builder.Property(b => b.CustomerCount).HasDefaultValue(0);
			builder.Property(b => b.TotalAmount).HasDefaultValue(0);
			builder.Property(b => b.IsDelete).HasDefaultValue("False");
		}
	}
}
