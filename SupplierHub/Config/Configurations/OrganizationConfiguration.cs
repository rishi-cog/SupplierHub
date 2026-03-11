using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
	{
		public void Configure(EntityTypeBuilder<Organization> builder)
		{
			builder.ToTable("organization");

			builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
			builder.Property(x => x.TaxId).HasMaxLength(50);

			builder.Property(x => x.Status).IsRequired()
				   .HasConversion<string>().HasMaxLength(20)
				   .HasDefaultValue("Active");

			builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

			// Indexes
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_org_status");
			builder.HasIndex(x => x.UpdatedOn).HasDatabaseName("idx_org_updatedon");
		}
	}
}