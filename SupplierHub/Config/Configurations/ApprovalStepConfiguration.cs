using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class ApprovalStepConfiguration : IEntityTypeConfiguration<ApprovalStep>
	{
		public void Configure(EntityTypeBuilder<ApprovalStep> builder)
		{
			builder.ToTable("ApprovalStep");

			builder.HasKey(x => x.StepID);

			builder.Property(x => x.PRID)
				   .IsRequired();

			builder.Property(x => x.ApproverID)
				   .IsRequired();

			builder.Property(x => x.Decision)
				   .IsRequired()
				   .HasMaxLength(20);

			builder.Property(x => x.DecisionDate);

			builder.Property(x => x.Remarks)
				   .HasMaxLength(500);

			// Foreign Keys
			builder.HasOne(x => x.Requisition)
				   .WithMany(x => x.ApprovalSteps)
				   .HasForeignKey(x => x.PRID)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.Approver)
				   .WithMany()
				   .HasForeignKey(x => x.ApproverID)
				   .OnDelete(DeleteBehavior.Restrict);

			// Indexes
			builder.HasIndex(x => x.PRID)
				   .HasDatabaseName("idx_approval_prid");

			builder.HasIndex(x => x.ApproverID)
				   .HasDatabaseName("idx_approval_approverid");

			builder.HasIndex(x => x.Decision)
				   .HasDatabaseName("idx_approval_decision");
		}
	}
}