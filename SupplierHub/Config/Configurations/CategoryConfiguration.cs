using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("category");

			builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

			builder.Property(x => x.Status).IsRequired()
				   .HasConversion<string>().HasMaxLength(20)
				   .HasDefaultValue("Active");

			builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

			// NEW: IsDeleted default
			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

			builder.HasOne(x => x.ParentCategory)
				   .WithMany(x => x.SubCategories)
				   .HasForeignKey(x => x.ParentCategoryId)
				   .OnDelete(DeleteBehavior.Restrict);

			// Indexes
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_category_status");
			builder.HasIndex(x => x.UpdatedOn).HasDatabaseName("idx_category_updatedon");
			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");
		}
	}
}