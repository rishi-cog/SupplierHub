using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;
using SupplierHub.Constants.Enum;

namespace SupplierHub.Config.Configurations
{
	public class ErpExportRefConfiguration : IEntityTypeConfiguration<ErpExportRef>
	{
		public void Configure(EntityTypeBuilder<ErpExportRef> builder)
		{
			builder.ToTable("erp_export_ref");

			builder.HasKey(x => x.ErpRefId);
			builder.Property(x => x.ErpRefId).HasColumnName("erpref_id");

			builder.Property(x => x.EntityType)
				.HasColumnName("entity_type")
				.HasConversion<string>()
				.HasMaxLength(30)
				.IsRequired();

			builder.Property(x => x.PayloadUri)
				.HasColumnName("payload_uri") 
				.HasMaxLength(500);

			builder.Property(x => x.CorrelationId)
				.HasColumnName("correlation_id") 
				.HasMaxLength(100);

			builder.Property(x => x.ExportDate).HasColumnName("export_date");

			builder.Property(x => x.Status)
				.HasColumnName("status")
				.HasConversion<string>()
				.HasMaxLength(30)
				.IsRequired()
				.HasDefaultValue(ErpExportRefStatus.Queued.ToString());

			// Timestamps using your Catalog style
			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
			builder.Property(x => x.CreatedOn)
				.HasColumnName("createdon")
				.IsRequired()
				.HasDefaultValueSql("GETUTCDATE()");

			builder.Property(x => x.UpdatedOn)
				.HasColumnName("updatedon")
				.HasDefaultValueSql("GETUTCDATE()");

			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");
		}
	}
}