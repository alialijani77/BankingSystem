using BankingSystem.Domain.Entities.Account.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BankingSystem.Infra.Data.FluentConfigs.Account.User
{
	public class UserKeyValueConfig : IEntityTypeConfiguration<Domain.Entities.Account.User.UserKeyValue>
	{
		public void Configure(EntityTypeBuilder<UserKeyValue> builder)
		{
			builder.HasKey(u => u.Key);
			builder.Property(u => u.Value).IsRequired().HasMaxLength(50);
			builder.HasData(new UserKeyValue()
			{
				Key = 1,
				Value = "PhoneNumber"
			});
			builder.HasData(new UserKeyValue()
			{
				Key = 2,
				Value = "Avatar"
			});
		}
	}
}
