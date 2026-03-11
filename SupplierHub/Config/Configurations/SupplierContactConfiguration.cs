using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class SupplierContactConfiguration : IEntityTypeConfiguration<SupplierContact>
	{
		public void Configure(EntityTypeBuilder<SupplierContact> builder)
		{
			builder.ToTable("supplier_contact");

			builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
			builder.Property(x => x.Email).HasMaxLength(150);
			builder.Property(x => x.Phone).HasMaxLength(30);
			builder.Property(x => x.Role).HasMaxLength(100);

			builder.Property(x => x.Status).IsRequired()
				   .HasConversion<string>().HasMaxLength(20)
				   .HasDefaultValue("Active");

			builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

			builder.HasOne(x => x.Supplier)
				   .WithMany(x => x.Contacts)
				   .HasForeignKey(x => x.SupplierId)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			// Indexes
			builder.HasIndex(x => x.SupplierId).HasDatabaseName("idx_contact_supplier");
			builder.HasIndex(x => x.Email).HasDatabaseName("idx_contact_email");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_contact_status");
			builder.HasIndex(x => x.UpdatedOn).HasDatabaseName("idx_contact_updatedon");
		}
	}
}