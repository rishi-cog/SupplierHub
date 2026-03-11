using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class SupplierRiskConfiguration : IEntityTypeConfiguration<SupplierRisk>
	{
		public void Configure(EntityTypeBuilder<SupplierRisk> builder)
		{
			builder.ToTable("supplier_risk");
        NEW: IsDeleted default
builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.Property(x => x.RiskType).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Score).HasColumnType("decimal(5,2)");
			builder.Property(x => x.Notes).HasMaxLength(500);

			builder.Property(x => x.AssessedDate)
				   .HasConversion(v => v.HasValue ? v.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
								  v => v.HasValue ? DateOnly.FromDateTime(v.Value) : (DateOnly?)null)
				   .HasColumnType("date");

			builder.Property(x => x.Status).IsRequired()
				   .HasConversion<string>().HasMaxLength(20)
				   .HasDefaultValue("Active");

			builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");
			// NEW: IsDeleted default
			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

			builder.HasOne(x => x.Supplier)
				   .WithMany(x => x.Risks)
				   .HasForeignKey(x => x.SupplierId)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			// Indexes
			builder.HasIndex(x => x.SupplierId).HasDatabaseName("idx_risk_supplier");
			builder.HasIndex(x => x.RiskType).HasDatabaseName("idx_risk_type");
			builder.HasIndex(x => x.AssessedDate).HasDatabaseName("idx_risk_assessed");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_risk_status");
			builder.HasIndex(x => x.UpdatedOn).HasDatabaseName("idx_risk_updatedon");
			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");

		}
	}
}