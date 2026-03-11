using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem>
	{
		public void Configure(EntityTypeBuilder<CatalogItem> builder)
		{
			builder.ToTable("catalog_item");

			builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
			builder.Property(x => x.MinOrderQty).HasColumnType("decimal(18,2)");
			builder.Property(x => x.Currency).IsRequired().HasMaxLength(10);

			builder.Property(x => x.Status).IsRequired()
				   .HasConversion<string>().HasMaxLength(20)
				   .HasDefaultValue("Active");

			builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

			builder.HasOne(x => x.Catalog)
				   .WithMany(x => x.CatalogItems)
				   .HasForeignKey(x => x.CatalogId)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			builder.HasOne(x => x.Item)
				   .WithMany(x => x.CatalogItems)
				   .HasForeignKey(x => x.ItemId)
				   .OnDelete(DeleteBehavior.Restrict)
				   .IsRequired();

			// Indexes
			builder.HasIndex(x => new { x.CatalogId, x.ItemId })
				   .IsUnique()
				   .HasDatabaseName("uq_catalog_item_pair");

			builder.HasIndex(x => x.Status).HasDatabaseName("idx_catalog_item_status");
			builder.HasIndex(x => x.UpdatedOn).HasDatabaseName("idx_catalog_item_updatedon");
		}
	}
}