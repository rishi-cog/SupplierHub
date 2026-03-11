using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class RequisitionConfiguration : IEntityTypeConfiguration<Requisition>
	{
		public void Configure(EntityTypeBuilder<Requisition> builder)
		{
			builder.ToTable("requisition");

			builder.Property(x => x.CostCenter).HasMaxLength(100);

			builder.Property(x => x.RequestedDate)
				   .IsRequired()
				   .HasDefaultValueSql("SYSDATETIMEOFFSET()");

			builder.Property(x => x.Status).IsRequired()
				   .HasConversion<string>().HasMaxLength(20)
				   .HasDefaultValue("Draft");

			// Indexes
			builder.HasIndex(x => x.RequesterID).HasDatabaseName("idx_req_requester");
			builder.HasIndex(x => x.OrgID).HasDatabaseName("idx_req_org");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_req_status");
			builder.HasIndex(x => x.RequestedDate).HasDatabaseName("idx_req_requesteddate");
		}
	}
}