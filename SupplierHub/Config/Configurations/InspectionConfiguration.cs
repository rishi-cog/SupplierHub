using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class InspectionConfiguration : IEntityTypeConfiguration<Inspection>
	{
		public void Configure(EntityTypeBuilder<Inspection> builder)
		{
			builder.ToTable("inspection");

			builder.Property(x => x.Result).IsRequired().HasMaxLength(10);

			builder.Property(x => x.InspDate)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

			builder.HasOne(x => x.GRNItem)
				   .WithMany()
				   .HasForeignKey(x => x.GRNItemID)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			// Indexes
			builder.HasIndex(x => x.GRNItemID).HasDatabaseName("idx_inspection_grnitem");
			builder.HasIndex(x => x.InspDate).HasDatabaseName("idx_inspection_date");
		}
	}
}