using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	[Table("grn_item_ref")]
	public class GRNItemRef
	{
		[Key]
		public int GRNItemID { get; set; }

		[Required]
		public int GRNID { get; set; }

		[Required]
		public int POLineID { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal ReceivedQty { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal AcceptedQty { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal RejectedQty { get; set; }

		[MaxLength(200)]
		public string? Reason { get; set; }

		// Navigation
		[ForeignKey(nameof(GRNID))]
		public virtual GRNRef GRN { get; set; }
	}
}