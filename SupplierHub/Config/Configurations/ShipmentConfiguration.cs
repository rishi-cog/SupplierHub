using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
	{
		public void Configure(EntityTypeBuilder<Shipment> builder)
		{
			builder.ToTable("Shipment");

			builder.HasKey(x => x.ShipmentID);

			builder.Property(x => x.POID)
				   .IsRequired();

			builder.Property(x => x.SupplierID)
				   .IsRequired();

			builder.Property(x => x.ShipDate)
				   .IsRequired();

			builder.Property(x => x.Carrier)
				   .HasMaxLength(100);

			builder.Property(x => x.TrackingNo)
				   .HasMaxLength(100);

			builder.Property(x => x.Status)
				   .IsRequired()
				   .HasMaxLength(20);

			// Foreign Keys
			builder.HasOne(x => x.PurchaseOrder)
				   .WithMany(x => x.Shipments)
				   .HasForeignKey(x => x.POID)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.Supplier)
				   .WithMany()
				   .HasForeignKey(x => x.SupplierID)
				   .OnDelete(DeleteBehavior.Restrict);

			// Indexes
			builder.HasIndex(x => x.POID)
				   .HasDatabaseName("idx_shipment_poid");

			builder.HasIndex(x => x.SupplierID)
				   .HasDatabaseName("idx_shipment_supplierid");

			builder.HasIndex(x => x.Status)
				   .HasDatabaseName("idx_shipment_status");

			builder.HasIndex(x => x.ShipDate)
				   .HasDatabaseName("idx_shipment_shipdate");
		}
	}
}