using BankingSystem.Domain.Entities.Account.User;
using BankingSystem.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infra.Data.FluentConfigs.Account.User
{
	internal class PermissionConfig : IEntityTypeConfiguration<Domain.Entities.Account.User.Permission>
	{
		public void Configure(EntityTypeBuilder<Permission> builder)
		{
			builder.HasKey(p => p.PermissionId);
			builder.Property(u => u.FaName).IsRequired().HasMaxLength(50);
			builder.Property(u => u.EnName).IsRequired().HasMaxLength(50);
			builder.Property(u => u.Count).HasDefaultValue(0);
			builder.HasData(new Permission()
			{
				PermissionId = 1,
				FaName = "مدیر سیستم",
				EnName = "System Manager",
				Count = 0,
				CreateUserId = 1
			});
			builder.HasData(new Permission()
			{
				PermissionId = 2,
				FaName = "کاربر سیستم",
				EnName = "user",
				Count = 0,
				CreateUserId = 1
			});
			//builder.HasData(new State()
			//{
			//	StateId = 2,
			//	Title = "شهر تهران",
			//	ParentId = 1
			//});
		}
	}
}
