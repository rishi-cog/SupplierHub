using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class ScorecardConfiguration : IEntityTypeConfiguration<Scorecard>
	{
		public void Configure(EntityTypeBuilder<Scorecard> builder)
		{
			builder.ToTable("scorecard");

			builder.Property(x => x.Period).IsRequired().HasMaxLength(7);

			// Unique per supplier-period
			builder.HasIndex(x => new { x.SupplierID, x.Period })
				   .IsUnique()
				   .HasDatabaseName("uq_scorecard_supplier_period");
		}
	}
}