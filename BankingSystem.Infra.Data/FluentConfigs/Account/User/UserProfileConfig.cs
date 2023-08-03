using BankingSystem.Domain.Entities.Account.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infra.Data.FluentConfigs.Account.User
{
	public class UserProfileConfig : IEntityTypeConfiguration<Domain.Entities.Account.User.UserProfile>
	{
		public void Configure(EntityTypeBuilder<UserProfile> builder)
		{
			builder.HasKey(u => u.UserProfileId);
			builder.HasOne(u => u.User).WithMany(u => u.UserProfiles).HasForeignKey("UserId");
			builder.HasOne(u => u.UserProfileKeyValue).WithMany(u => u.UserProfiles).HasForeignKey("Key");
		}
	}
}
