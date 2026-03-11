using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class PRLineConfiguration : IEntityTypeConfiguration<PRLine>
	{
		public void Configure(EntityTypeBuilder<PRLine> builder)
		{
			builder.ToTable("PRLine");

			builder.HasKey(x => x.PRLineID);

			builder.Property(x => x.PRID)
				   .IsRequired();

			builder.Property(x => x.ItemID)
				   .IsRequired();

			builder.Property(x => x.Description)
				   .HasMaxLength(int.MaxValue);

			builder.Property(x => x.Qty)
				   .IsRequired();

			builder.Property(x => x.UoM)
				   .HasMaxLength(20);

			builder.Property(x => x.TargetPrice)
				   .IsRequired();

			builder.Property(x => x.Currency)
				   .HasMaxLength(3)
				   .HasDefaultValue("USD");

			builder.Property(x => x.SupplierPreferredID);

			builder.Property(x => x.Notes)
				   .HasMaxLength(500);

			// Foreign Keys
			builder.HasOne(x => x.Requisition)
				   .WithMany(x => x.PRLines)
				   .HasForeignKey(x => x.PRID)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.Item)
				   .WithMany()
				   .HasForeignKey(x => x.ItemID)
				   .OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.SupplierPreferred)
				   .WithMany()
				   .HasForeignKey(x => x.SupplierPreferredID)
				   .OnDelete(DeleteBehavior.SetNull);

			// Indexes
			builder.HasIndex(x => x.PRID)
				   .HasDatabaseName("idx_prline_prid");

			builder.HasIndex(x => x.ItemID)
				   .HasDatabaseName("idx_prline_itemid");

			builder.HasIndex(x => x.SupplierPreferredID)
				   .HasDatabaseName("idx_prline_supplierid");
		}
	}
}