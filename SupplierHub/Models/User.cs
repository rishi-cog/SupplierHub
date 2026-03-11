using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Models;
using SupplierHub.Constants.Enum;


namespace SupplierHub.Models
{
	[Table("users")]
	public class User
	{
		[Key]
		public int UserId { get; set; }

		[Required, MaxLength(120)]
		public string Name { get; set; }

		[Required, MaxLength(120)]
		public string Email { get; set; }

		[MaxLength(30)]
		public string? Phone { get; set; }

		[Required]
		public UserRole Role { get; set; }

		[Required]
		public UserStatus Status { get; set; }

		[Required]
		public string PasswordHash { get; set; }

		[Required]
		public DateTime CreatedAtUtc { get; set; }

		public DateTime? LastLoginAtUtc { get; set; }

		public bool IsDeleted { get; set; }	 // default -> false

		public ICollection<RFxEvent> Events { get; set; }

		public ICollection<SystemConfig> systemConfigs { get; set; }
	}
}