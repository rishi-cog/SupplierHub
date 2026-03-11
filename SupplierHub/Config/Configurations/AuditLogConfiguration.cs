using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models.IAM;

namespace SupplierHub.Config.Configurations
{
	public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
	{
		public void Configure(EntityTypeBuilder<AuditLog> builder)
		{
			builder.ToTable("AuditLogs");

			// Constraints for string columns as per your model annotations
			builder.Property(x => x.Action)
				   .IsRequired()
				   .HasMaxLength(80);

			builder.Property(x => x.Resource)
				   .IsRequired()
				   .HasMaxLength(120);

			// Defaults
			builder.Property(x => x.TimestampUtc)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");
			// Indexes (query accelerators)
			builder.HasIndex(x => x.TimestampUtc).HasDatabaseName("idx_auditlogs_timestamputc");
			builder.HasIndex(x => x.Resource).HasDatabaseName("idx_auditlogs_resource");
			builder.HasIndex(x => x.UserId).HasDatabaseName("idx_auditlogs_userid");
		}
	}
}
