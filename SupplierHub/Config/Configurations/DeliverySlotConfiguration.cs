using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class DeliverySlotConfiguration : IEntityTypeConfiguration<DeliverySlot>
	{
		public void Configure(EntityTypeBuilder<DeliverySlot> builder)
		{
			builder.ToTable("DeliverySlot");

			builder.HasKey(x => x.SlotID);

			builder.Property(x => x.SiteID)
				   .IsRequired();

			builder.Property(x => x.SlotDate)
				   .IsRequired();

			builder.Property(x => x.StartTime)
				   .IsRequired();

			builder.Property(x => x.EndTime)
				   .IsRequired();

			builder.Property(x => x.Capacity)
				   .IsRequired();

			builder.Property(x => x.Status)
				   .IsRequired()
				   .HasMaxLength(20);

			// Foreign Keys
			builder.HasOne(x => x.Site)
				   .WithMany()
				   .HasForeignKey(x => x.SiteID)
				   .OnDelete(DeleteBehavior.Restrict);

			// Indexes
			builder.HasIndex(x => x.SiteID)
				   .HasDatabaseName("idx_deliveryslot_siteid");

			builder.HasIndex(x => x.SlotDate)
				   .HasDatabaseName("idx_deliveryslot_slotdate");

			builder.HasIndex(x => x.Status)
				   .HasDatabaseName("idx_deliveryslot_status");
		}
	}
}