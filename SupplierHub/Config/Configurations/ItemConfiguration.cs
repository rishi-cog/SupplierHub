using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class ItemConfiguration : IEntityTypeConfiguration<Item>
	{
		public void Configure(EntityTypeBuilder<Item> builder)
		{
			builder.ToTable("item");

			builder.Property(x => x.Sku).IsRequired().HasMaxLength(100);
			builder.Property(x => x.Description).HasMaxLength(500);
			builder.Property(x => x.Uom).HasMaxLength(30);

			builder.Property(x => x.Status).IsRequired()
				   .HasConversion<string>().HasMaxLength(20)
				   .HasDefaultValue("Active");

			builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");
			// NEW: IsDeleted default
			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

			builder.HasOne(x => x.Category)
				   .WithMany(x => x.Items)
				   .HasForeignKey(x => x.CategoryId)
				   .OnDelete(DeleteBehavior.Restrict)
				   .IsRequired();

			// Indexes
			builder.HasIndex(x => x.CategoryId).HasDatabaseName("idx_item_category");
			builder.HasIndex(x => x.Sku).IsUnique().HasDatabaseName("uq_item_sku");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_item_status");
			builder.HasIndex(x => x.UpdatedOn).HasDatabaseName("idx_item_updatedon");
			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");

		}
	}
}