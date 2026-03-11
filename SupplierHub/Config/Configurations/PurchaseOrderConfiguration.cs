using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;
using SupplierHub.Constants.Enum;

namespace SupplierHub.Config.Configurations
{
	public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
	{
		public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
		{
			builder.ToTable("purchase_order");

			builder.Property(x => x.Currency).HasMaxLength(10);
			builder.Property(x => x.Incoterms).HasMaxLength(50);
			builder.Property(x => x.PaymentTerms).HasMaxLength(100);

			// Status Enum Conversion
			builder.Property(x => x.Status).IsRequired()
				.HasConversion<string>().HasMaxLength(50)
				.HasDefaultValue(PurchaseOrderStatus.Open.ToString());

			// Timestamps
			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
			builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

			// Indexes
			builder.HasIndex(x => x.OrgId).HasDatabaseName("idx_po_org");
			builder.HasIndex(x => x.SupplierId).HasDatabaseName("idx_po_supplier");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_po_status");
			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");
		}
	}
}