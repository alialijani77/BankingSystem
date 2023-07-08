using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infra.Data.FluentConfigs.Account.Customer
{
	public class CustomerConfig : IEntityTypeConfiguration<Domain.Entities.Account.Customer.Customer>
	{
		public void Configure(EntityTypeBuilder<Domain.Entities.Account.Customer.Customer> builder)
		{
			builder.HasKey(c => c.CustomerId);
			builder.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
			builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);
			builder.Property(c => c.NationalCode).IsRequired().HasMaxLength(20);
			builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(20);


		}
	}
}
