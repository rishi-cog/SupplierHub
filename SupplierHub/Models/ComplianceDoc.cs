using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	[Table("compliance_doc")]
	public class ComplianceDoc
	{
		[Key]
		public long DocId { get; set; }

		[Required]
		public long SupplierId { get; set; }

		[Required, MaxLength(50)]
		public string DocType { get; set; }

		[MaxLength(500)]
		public string? FileUri { get; set; }

		public DateOnly? IssueDate { get; set; }
		public DateOnly? ExpiryDate { get; set; }

		[Required]
		public ComplianceDocStatus Status { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }

		public bool IsDeleted { get; set; }  // default -> false

		// Navigation
		[ForeignKey(nameof(SupplierId))]
		public virtual Supplier Supplier { get; set; }
	}
}