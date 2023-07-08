using BankingSystem.Domain.Entities.Account.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infra.Data.FluentConfigs.Account.Customer
{
	public class OpenAccountCustomerConfig : IEntityTypeConfiguration<Domain.Entities.Account.Customer.OpenAccountCustomer>
	{
		public void Configure(EntityTypeBuilder<OpenAccountCustomer> builder)
		{
			builder.HasKey(o => o.Id);
			builder.HasOne(o=>o.Customer).WithMany(o=>o.OpenAccountCustomers).HasForeignKey(o=>o.CustomerId);
			builder.HasOne(o => o.OpenAccount).WithMany(o => o.OpenAccountCustomers).HasForeignKey(o => o.OpenAccountId);

		}
	}
}
