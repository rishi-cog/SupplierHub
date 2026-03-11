using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class POLineConfiguration : IEntityTypeConfiguration<POLine>
	{
		public void Configure(EntityTypeBuilder<POLine> builder)
		{
			builder.ToTable("po_line");

			builder.Property(x => x.Qty).HasPrecision(18, 3);
			builder.Property(x => x.UnitPrice).HasPrecision(18, 4);
			builder.Property(x => x.LineTotal).HasPrecision(18, 2);

			builder.Property(x => x.Status).IsRequired()
				.HasConversion<string>().HasMaxLength(30)
				.HasDefaultValue("ACTIVE");

			builder.HasOne(x => x.PurchaseOrder)
				.WithMany(p => p.OrderLines)
				.HasForeignKey(x => x.PoId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");
		}
	}
}