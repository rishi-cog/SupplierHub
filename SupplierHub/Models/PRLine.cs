using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	public class PRLine
	{
		[Key]
		public long PRLineID { get; set; }
		public long PRID { get; set; }
		[ForeignKey("PRID")]
		public virtual Requisition Requisition { get; set; }

		public long ItemID { get; set; }
		[ForeignKey("ItemID")]
		public string Description { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal Qty { get; set; }
		public string UoM { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal? TargetPrice { get; set; }
		public string Currency { get; set; } = "USD";
		public long? SupplierPreferredID { get; set; }
		[ForeignKey("SupplierPreferredID")]
		public string Notes { get; set; }
	}
}