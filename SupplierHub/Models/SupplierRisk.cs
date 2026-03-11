using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	[Table("supplier_risk")]
	public class SupplierRisk
	{
		[Key]
		public long RiskId { get; set; }

		[Required]
		public long SupplierId { get; set; }

		[Required, MaxLength(50)]
		public string RiskType { get; set; }

		[Column(TypeName = "decimal(5,2)")]
		public decimal? Score { get; set; }

		public DateOnly? AssessedDate { get; set; }

		[MaxLength(500)]
		public string? Notes { get; set; }

		[Required]
		public SupplierRiskStatus Status { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }

		public bool IsDeleted { get; set; }  // default -> false

		// Navigation
		[ForeignKey(nameof(SupplierId))]
		public virtual Supplier Supplier { get; set; }
	}
}