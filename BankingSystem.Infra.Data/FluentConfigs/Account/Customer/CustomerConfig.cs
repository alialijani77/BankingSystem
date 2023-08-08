using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infra.Data.FluentConfigs.Account.Customer
{
	public class CustomerConfig : IEntityTypeConfiguration<Domain.Entities.Account.Customer.Customer>
	{
		public void Configure(EntityTypeBuilder<Domain.Entities.Account.Customer.Customer> builder)
		{
			builder.HasKey(c => c.CustomerId);
			builder.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
			builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);
			builder.Property(c => c.NationalCode).IsRequired().HasMaxLength(10);
			builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(15);
			builder.Property(c => c.SignatureImage).IsRequired().HasMaxLength(250);

		}
	}
}
