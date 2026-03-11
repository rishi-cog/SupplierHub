using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;
using SupplierHub.Constants.Enum;

namespace SupplierHub.Config.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("users");

			builder.Property(x => x.Name).IsRequired().HasMaxLength(120);
			builder.Property(x => x.Email).IsRequired().HasMaxLength(120);
			builder.Property(x => x.Name).IsRequired().HasMaxLength(60);

			// Enums as string
			builder.Property(x => x.Role)
				   .IsRequired()
				   .HasConversion<string>()
				   .HasMaxLength(30);

			builder.Property(x => x.Status)
				   .IsRequired()
				   .HasConversion<string>()
				   .HasMaxLength(20)
				   .HasDefaultValue("Active");

			// Timestamps
			builder.Property(x => x.CreatedAtUtc)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

			// Indexes (at the end)
			builder.HasIndex(x => x.Email).IsUnique().HasDatabaseName("uq_users_email");
			builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName("uq_users_username");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_users_status");
		}
	}
}