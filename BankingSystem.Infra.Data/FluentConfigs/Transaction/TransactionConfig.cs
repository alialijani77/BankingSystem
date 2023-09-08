using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infra.Data.FluentConfigs.Transaction
{
	internal class TransactionConfig : IEntityTypeConfiguration<Domain.Entities.Transaction.Transaction>
	{
		public void Configure(EntityTypeBuilder<Domain.Entities.Transaction.Transaction> builder)
		{
			builder.HasKey(t => t.Id);
			builder.Property(t => t.SrcCardNumber).IsRequired().HasMaxLength(16);
			builder.Property(t => t.DstCardNumber).IsRequired().HasMaxLength(16);
			builder.Property(t => t.Amount).IsRequired();
			builder.Property(t => t.TrnSeq).IsRequired();
			builder.HasIndex(t => t.SrcCardNumber);
			builder.HasIndex(t => t.DstCardNumber);

		}
	}
}
