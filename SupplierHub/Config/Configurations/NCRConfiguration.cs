using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class NCRConfiguration : IEntityTypeConfiguration<NCR>
	{
		public void Configure(EntityTypeBuilder<NCR> builder)
		{
			builder.ToTable("ncr");

			builder.Property(x => x.DefectType).IsRequired().HasMaxLength(100);
			builder.Property(x => x.Severity).IsRequired().HasMaxLength(20);
			builder.Property(x => x.Disposition).IsRequired().HasMaxLength(20);
			builder.Property(x => x.Notes).HasMaxLength(500);
			builder.Property(x => x.Status).IsRequired().HasMaxLength(20)
				   .HasDefaultValue("Open");

			builder.HasOne(x => x.GRNItem)
				   .WithMany()
				   .HasForeignKey(x => x.GRNItemID)
				   .OnDelete(DeleteBehavior.Restrict)
				   .IsRequired();

			// Indexes
			builder.HasIndex(x => x.GRNItemID).HasDatabaseName("idx_ncr_grnitem");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_ncr_status");
			builder.HasIndex(x => x.Severity).HasDatabaseName("idx_ncr_severity");
		}
	}
}