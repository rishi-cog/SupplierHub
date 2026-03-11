using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
	{
		public void Configure(EntityTypeBuilder<Catalog> builder)
		{
			builder.ToTable("catalog");

			builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

			builder.Property(x => x.ValidFrom)
				   .HasConversion(v => v.HasValue ? v.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
								  v => v.HasValue ? DateOnly.FromDateTime(v.Value) : (DateOnly?)null)
				   .HasColumnType("date");

			builder.Property(x => x.ValidTo)
				   .HasConversion(v => v.HasValue ? v.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
								  v => v.HasValue ? DateOnly.FromDateTime(v.Value) : (DateOnly?)null)
				   .HasColumnType("date");

			// Status / timestamps
			builder.Property(x => x.Status).IsRequired()
				   .HasConversion<string>().HasMaxLength(20)
				   .HasDefaultValue("Active");

			builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

			builder.HasOne(x => x.Supplier)
				   .WithMany(s => s.Catalogs)
				   .HasForeignKey(x => x.SupplierId)
				   .OnDelete(DeleteBehavior.Restrict)
				   .IsRequired();

			// Indexes (end)
			builder.HasIndex(x => x.SupplierId).HasDatabaseName("idx_catalog_supplier");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_catalog_status");
			builder.HasIndex(x => x.UpdatedOn).HasDatabaseName("idx_catalog_updatedon");
		}
	}
}