﻿using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infra.Data.FluentConfigs.Account.User
{
	public class UserConfig : IEntityTypeConfiguration<Domain.Entities.Account.User.User>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.Account.User.User> builder)
		{
			builder.HasKey(u => u.UserId);
			builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
			builder.Property(u => u.Family).IsRequired().HasMaxLength(100);
			builder.Property(u => u.Password).IsRequired().HasMaxLength(250);
			builder.Property(u => u.NationalCode).IsRequired().HasMaxLength(10);
			builder.Property(u => u.Value).IsRequired().HasMaxLength(250);
			builder.Property(u => u.CreateUserId).IsRequired();
			builder.HasOne(u => u.Branch).WithMany(u => u.Users).HasForeignKey("BranchId");
			builder.HasOne(u => u.Permission).WithMany(u => u.Users).HasForeignKey("PermissionId");
			builder.HasOne(u => u.UserKeyValue).WithMany(u => u.Users).HasForeignKey("Key");

		}
	}
}
