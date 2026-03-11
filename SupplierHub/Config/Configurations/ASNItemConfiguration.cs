using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class ASNItemConfiguration : IEntityTypeConfiguration<ASNItem>
	{
		public void Configure(EntityTypeBuilder<ASNItem> builder)
		{
			builder.ToTable("ASNItem");

			builder.HasKey(x => x.ASNItemID);

			builder.Property(x => x.ASNID)
				   .IsRequired();

			builder.Property(x => x.POLineID)
				   .IsRequired();

			builder.Property(x => x.ShippedQty)
				   .IsRequired();

			builder.Property(x => x.LotBatch)
				   .HasMaxLength(100);

			builder.Property(x => x.SerialJSON)
				   .HasMaxLength(int.MaxValue);

			builder.Property(x => x.Notes)
				   .HasMaxLength(500);

			// Foreign Keys
			builder.HasOne(x => x.ASN)
				   .WithMany(x => x.ASNItems)
				   .HasForeignKey(x => x.ASNID)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.POLine)
				   .WithMany()
				   .HasForeignKey(x => x.POLineID)
				   .OnDelete(DeleteBehavior.Restrict);

			// Indexes
			builder.HasIndex(x => x.ASNID)
				   .HasDatabaseName("idx_asnitem_asnid");

			builder.HasIndex(x => x.POLineID)
				   .HasDatabaseName("idx_asnitem_polineid");
		}
	}
}