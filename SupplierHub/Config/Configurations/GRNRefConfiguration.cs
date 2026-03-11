using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class GRNRefConfiguration : IEntityTypeConfiguration<GRNRef>
	{
		public void Configure(EntityTypeBuilder<GRNRef> builder)
		{
			builder.ToTable("grn_ref");

			builder.Property(x => x.ReceivedBy).IsRequired().HasMaxLength(150);
			builder.Property(x => x.Status).IsRequired().HasMaxLength(20)
				   .HasDefaultValue("Open");

			// timestamps
			builder.Property(x => x.ReceivedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

			// Indexes
			builder.HasIndex(x => x.POID).HasDatabaseName("idx_grn_po");
			builder.HasIndex(x => x.ASNID).HasDatabaseName("idx_grn_asn");
			builder.HasIndex(x => x.ReceivedDate).HasDatabaseName("idx_grn_receiveddate");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_grn_status");
		}
	}
}