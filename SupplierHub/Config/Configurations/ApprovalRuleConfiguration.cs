using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class ApprovalRuleConfiguration : IEntityTypeConfiguration<ApprovalRule>
	{
		public void Configure(EntityTypeBuilder<ApprovalRule> builder)
		{
			builder.ToTable("approval_rule");

			builder.Property(x => x.Scope).HasMaxLength(20);
			builder.Property(x => x.Severity).HasConversion<string>().HasMaxLength(20);

			// bool status default
			builder.Property(x => x.Status).IsRequired().HasDefaultValue(false);

			// Indexes
			builder.HasIndex(x => x.Severity).HasDatabaseName("idx_approval_rule_severity");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_approval_rule_status");
		}
	}
}