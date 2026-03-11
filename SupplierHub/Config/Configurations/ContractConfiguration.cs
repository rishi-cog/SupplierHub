using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class ContractConfiguration : IEntityTypeConfiguration<Contract>
	{
		public void Configure(EntityTypeBuilder<Contract> builder)
		{
			builder.ToTable("contract");

			builder.Property(x => x.Rate).HasColumnType("decimal(18,4)");
			builder.Property(x => x.Currency).HasMaxLength(10);

			builder.Property(x => x.ValidFrom)
				   .HasConversion(v => v.HasValue ? v.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
								  v => v.HasValue ? DateOnly.FromDateTime(v.Value) : (DateOnly?)null)
				   .HasColumnType("date");

			builder.Property(x => x.ValidTo)
				   .HasConversion(v => v.HasValue ? v.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
								  v => v.HasValue ? DateOnly.FromDateTime(v.Value) : (DateOnly?)null)
				   .HasColumnType("date");

			builder.Property(x => x.Status).IsRequired()
				   .HasConversion<string>().HasMaxLength(20)
				   .HasDefaultValue("Active");

			builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETUTCDATE()");

			builder.HasOne(x => x.Supplier)
				   .WithMany()
				   .HasForeignKey(x => x.SupplierId)
				   .OnDelete(DeleteBehavior.Restrict)
				   .IsRequired();

			builder.HasOne(x => x.Item)
				   .WithMany(x => x.Contracts)
				   .HasForeignKey(x => x.ItemId)
				   .OnDelete(DeleteBehavior.SetNull);

			// Indexes
			builder.HasIndex(x => x.SupplierId).HasDatabaseName("idx_contract_supplier");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_contract_status");
			builder.HasIndex(x => x.UpdatedOn).HasDatabaseName("idx_contract_updatedon");
		}
	}
}