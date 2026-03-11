using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class ComplianceDocConfiguration : IEntityTypeConfiguration<ComplianceDoc>
	{
		public void Configure(EntityTypeBuilder<ComplianceDoc> builder)
		{
			builder.ToTable("compliance_doc");

			builder.Property(x => x.DocType).IsRequired().HasMaxLength(50);
			builder.Property(x => x.FileUri).HasMaxLength(500);

			builder.Property(x => x.IssueDate)
				   .HasConversion(v => v.HasValue ? v.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
								  v => v.HasValue ? DateOnly.FromDateTime(v.Value) : (DateOnly?)null)
				   .HasColumnType("date");

			builder.Property(x => x.ExpiryDate)
				   .HasConversion(v => v.HasValue ? v.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
								  v => v.HasValue ? DateOnly.FromDateTime(v.Value) : (DateOnly?)null)
				   .HasColumnType("date");

			builder.Property(x => x.Status).IsRequired()
				   .HasConversion<string>().HasMaxLength(20)
				   .HasDefaultValue("Active");

			builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

			builder.HasOne(x => x.Supplier)
				   .WithMany(x => x.ComplianceDocs)
				   .HasForeignKey(x => x.SupplierId)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			// Indexes
			builder.HasIndex(x => x.SupplierId).HasDatabaseName("idx_comp_supplier");
			builder.HasIndex(x => x.DocType).HasDatabaseName("idx_comp_doctype");
			builder.HasIndex(x => x.ExpiryDate).HasDatabaseName("idx_comp_expiry");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_comp_status");
			builder.HasIndex(x => x.UpdatedOn).HasDatabaseName("idx_comp_updatedon");
		}
	}
}