using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	[Table("supplier_contact")]
	public class SupplierContact
	{
		[Key]
		public long ContactId { get; set; }

		[Required]
		public long SupplierId { get; set; }

		[Required, MaxLength(150)]
		public string Name { get; set; }

		[MaxLength(150)]
		public string? Email { get; set; }

		[MaxLength(30)]
		public string? Phone { get; set; }

		[MaxLength(100)]
		public string? Role { get; set; }

		[Required]
		public ContactStatus Status { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }

		// Navigation
		[ForeignKey(nameof(SupplierId))]
		public virtual Supplier Supplier { get; set; }
	}
}