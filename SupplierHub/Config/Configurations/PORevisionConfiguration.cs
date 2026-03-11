using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class PORevisionConfiguration : IEntityTypeConfiguration<PORevision>
	{
		public void Configure(EntityTypeBuilder<PORevision> builder)
		{
			builder.ToTable("po_revision");

			// Handling the JSON column as a string in C#
			builder.Property(x => x.ChangelogJson).HasColumnType("json");

			builder.Property(x => x.Status)
				.HasConversion<string>().HasMaxLength(30)
				.HasDefaultValue("Active");

			builder.Property(x => x.ChangeDate).HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");
		}
	}
}