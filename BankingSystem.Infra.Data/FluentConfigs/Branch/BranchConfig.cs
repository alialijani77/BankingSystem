using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infra.Data.FluentConfigs.Branch
{
	public class BranchConfig : IEntityTypeConfiguration<BankingSystem.Domain.Entities.Branch.Branch>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BankingSystem.Domain.Entities.Branch.Branch> builder)
		{
			builder.HasKey(b => b.BranchId);
			builder.Property(b => b.BranchName).IsRequired().HasMaxLength(20);
			builder.Property(b => b.BranchCode).IsRequired().HasMaxLength(4);
			builder.Property(b => b.Address).IsRequired().HasMaxLength(250);
			builder.Property(b => b.CreateUserId).IsRequired();
			builder.Property(b => b.CustomerCount).HasDefaultValue(0);
			builder.Property(b => b.TotalAmount).HasDefaultValue(0);
			builder.Property(b => b.IsDelete).HasDefaultValue("False");
			builder.HasIndex(b => b.BranchCode);
			builder.HasData(new Domain.Entities.Branch.Branch()
			{
				BranchId = 1,
				BranchCode = "1",
				BranchName = "مرکزی",
				Address = "تهران",
				CustomerCount = 1,
				CityId = 2,
				StateId = 1,
				TotalAmount = 0,
				CreateUserId = 1
			});
		}
	}
}
