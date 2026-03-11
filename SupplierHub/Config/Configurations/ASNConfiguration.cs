using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class ASNConfiguration : IEntityTypeConfiguration<ASN>
	{
		public void Configure(EntityTypeBuilder<ASN> builder)
		{
			builder.ToTable("ASN");

			builder.HasKey(x => x.ASNID);

			builder.Property(x => x.ShipmentID)
				   .IsRequired();

			builder.Property(x => x.ASNNo)
				   .IsRequired()
				   .HasMaxLength(100);

			builder.Property(x => x.CreatedDate)
				   .IsRequired();

			builder.Property(x => x.Status)
				   .IsRequired()
				   .HasMaxLength(20);

			// Foreign Keys
			builder.HasOne(x => x.Shipment)
				   .WithMany(x => x.ASNs)
				   .HasForeignKey(x => x.ShipmentID)
				   .OnDelete(DeleteBehavior.Cascade);

			// Indexes
			builder.HasIndex(x => x.ShipmentID)
				   .HasDatabaseName("idx_asn_shipmentid");

			builder.HasIndex(x => x.ASNNo)
				   .HasDatabaseName("idx_asn_asnno");

			builder.HasIndex(x => x.Status)
				   .HasDatabaseName("idx_asn_status");

			builder.HasIndex(x => x.CreatedDate)
				   .HasDatabaseName("idx_asn_createddate");
		}
	}
}