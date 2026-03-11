using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Constants.Enum;
using SupplierHub.Models;
using System.Collections;

namespace SupplierHub.Config.Configurations
{
	public class POAckConfiguration : IEntityTypeConfiguration<PoAck>
	{
		public void Configure(EntityTypeBuilder<PoAck> builder)
		{
			builder.ToTable("po_ack");

			builder.Property(x => x.Decision)
				.HasConversion<string>().HasMaxLength(30)
				.HasDefaultValue(PoAckDecision.Accept.ToString());

			builder.Property(x => x.Status)
				.HasConversion<string>().HasMaxLength(30)
				.HasDefaultValue(PoAckStatus.Active.ToString());

			builder.Property(x => x.CounterNotes).HasMaxLength(500);

			builder.Property(x => x.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");
		}
	}
}