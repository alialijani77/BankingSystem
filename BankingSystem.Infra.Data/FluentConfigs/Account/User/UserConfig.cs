using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infra.Data.FluentConfigs.Account.User
{
	public class UserConfig : IEntityTypeConfiguration<Domain.Entities.Account.User.User>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.Account.User.User> builder)
		{
			builder.HasKey(u => u.UserId);
			builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
			builder.Property(u => u.Family).IsRequired().HasMaxLength(100);
			builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(20);
			builder.Property(u => u.Password).IsRequired().HasMaxLength(250);
			builder.Property(u => u.NationalCode).IsRequired().HasMaxLength(10);
			builder.Property(u => u.Address).IsRequired().HasMaxLength(250);
			builder.Property(u => u.CreateUserId).IsRequired();
			builder.HasOne(u => u.Branch).WithMany(u => u.Users).HasForeignKey(u => u.BranchId);
			builder.HasOne(u => u.Permission).WithMany(u => u.Users).HasForeignKey(u => u.PermissionId);


		}
	}
}
