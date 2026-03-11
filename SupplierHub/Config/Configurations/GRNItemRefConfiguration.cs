using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class GRNItemRefConfiguration : IEntityTypeConfiguration<GRNItemRef>
	{
		public void Configure(EntityTypeBuilder<GRNItemRef> builder)
		{
			builder.ToTable("grn_item_ref");

			builder.Property(x => x.ReceivedQty).HasColumnType("decimal(18,2)");
			builder.Property(x => x.AcceptedQty).HasColumnType("decimal(18,2)");
			builder.Property(x => x.RejectedQty).HasColumnType("decimal(18,2)");
			builder.Property(x => x.Reason).HasMaxLength(200);

			builder.HasOne(x => x.GRN)
				   .WithMany(x => x.Items)
				   .HasForeignKey(x => x.GRNID)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			// Indexes
			builder.HasIndex(x => x.GRNID).HasDatabaseName("idx_grnitem_grn");
			builder.HasIndex(x => x.POLineID).HasDatabaseName("idx_grnitem_poline");
		}
	}
}