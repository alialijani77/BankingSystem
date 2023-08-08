using BankingSystem.Domain.Entities.Account.User;
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
		}
	}
}
