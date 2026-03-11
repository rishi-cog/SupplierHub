using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class SupplierKPIConfiguration : IEntityTypeConfiguration<SupplierKPI>
	{
		public void Configure(EntityTypeBuilder<SupplierKPI> builder)
		{
			// Table
			builder.ToTable("supplier_kpi");

			// Key
			builder.HasKey(x => x.KPIID);

			// Required & lengths
			builder.Property(x => x.Period)
				   .IsRequired()
				   .HasMaxLength(7);

			// Decimal precisions (since model has no [Column(TypeName=...)] attributes)
			builder.Property(x => x.OTIFPct)
				   .HasColumnType("decimal(5,2)");

			builder.Property(x => x.NCRRatePPM)
				   .HasColumnType("decimal(18,2)");

			builder.Property(x => x.AvgAckTimeHrs)
				   .HasColumnType("decimal(10,2)");

			builder.Property(x => x.PriceAdherencePct)
				   .HasColumnType("decimal(5,2)");

			builder.Property(x => x.Score)
				   .HasColumnType("decimal(6,2)");

			// Timestamp default (kept in configuration per your rule)
			builder.Property(x => x.GeneratedDate)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");
			// If you're on MySQL instead of SQL Server, use:
			// .HasDefaultValueSql("CURRENT_TIMESTAMP");

			// Relationship: SupplierKPI -> Supplier (no back-collection required on Supplier)
			builder.HasOne<Supplier>()
				   .WithMany()                 // keep this if Supplier has no ICollection<SupplierKPI>
				   .HasForeignKey(x => x.SupplierID)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			// Indexes (complete)
			// Common pattern: enforce one KPI snapshot per supplier per period
			builder.HasIndex(x => new { x.SupplierID, x.Period })
				   .IsUnique()
				   .HasDatabaseName("uq_supplierkpi_supplier_period");

			// Helpful additional non-unique indexes for queries
			builder.HasIndex(x => x.SupplierID)
				   .HasDatabaseName("idx_supplierkpi_supplier");

			builder.HasIndex(x => x.Period)
				   .HasDatabaseName("idx_supplierkpi_period");
		}
	}
}