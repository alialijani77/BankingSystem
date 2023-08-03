using BankingSystem.Domain.Entities.Account.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infra.Data.FluentConfigs.Account.User
{
	internal class UserProfileKeyValueConfig : IEntityTypeConfiguration<Domain.Entities.Account.User.UserProfileKeyValue>
	{
		public void Configure(EntityTypeBuilder<UserProfileKeyValue> builder)
		{
			builder.HasKey(u => u.Key);
			builder.Property(u => u.Value).IsRequired().HasMaxLength(50);
			builder.HasData(new UserKeyValue()
			{
				Key = 1,
				Value = "Address"
			});
		
		}
	}
}
