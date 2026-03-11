using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
	{
		public void Configure(EntityTypeBuilder<Supplier> builder)
		{
			builder.ToTable("supplier");

			builder.Property(x => x.LegalName).IsRequired().HasMaxLength(200);
			builder.Property(x => x.DunsOrRegNo).HasMaxLength(50);
			builder.Property(x => x.TaxId).HasMaxLength(50);

			builder.Property(x => x.Status).IsRequired()
				   .HasConversion<string>().HasMaxLength(20)
				   .HasDefaultValue("Active");

			builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");
			// NEW: IsDeleted default
			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

			builder.HasOne(x => x.PrimaryContact)
				   .WithMany()
				   .HasForeignKey(x => x.PrimaryContactId)
				   .OnDelete(DeleteBehavior.SetNull);

			// Indexes
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_supplier_status");
			builder.HasIndex(x => x.UpdatedOn).HasDatabaseName("idx_supplier_updatedon");
			builder.HasIndex(x => x.LegalName).HasDatabaseName("idx_supplier_legalname");
			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");

		}
	}
}