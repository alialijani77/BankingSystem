using BankingSystem.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infra.Data.FluentConfigs.Account.Customer
{
    public class StateConfig : IEntityTypeConfiguration<State>
	{
		public void Configure(EntityTypeBuilder<State> builder)
		{
			builder.HasKey(s => s.StateId);
			builder.Property(s=>s.Title).IsRequired().HasMaxLength(50);
			builder.HasMany(s => s.CustomerStates).WithOne(s => s.State).HasForeignKey(s => s.StateId);
			builder.HasMany(s => s.CustomerCities).WithOne(s => s.City).HasForeignKey(s => s.CityId);
			builder.HasMany(s => s.BranchStates).WithOne(s => s.State).HasForeignKey("StateId");
			builder.HasMany(s => s.BranchCities).WithOne(s => s.City).HasForeignKey("CityId");
			builder.HasData(new State()
			{
				StateId = 1,
				Title = "تهران"
			});
			builder.HasData(new State()
			{
				StateId = 2,
				Title = "شهر تهران",
				ParentId = 1
			});
		}
	}
}
