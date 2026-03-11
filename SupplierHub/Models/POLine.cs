using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	[Table("po_line")]
	public class POLine
	{
		[Key]
		[Column("po_line_id")]
		public long PoLineId { get; set; }

		[Required]
		[Column("po_id")]
		public long PoId { get; set; }

		[ForeignKey("PoId")]
		public virtual PurchaseOrder PurchaseOrder { get; set; }

		[Column("item_id")]
		public long? ItemId { get; set; }

		[Column("description")]
		[StringLength(500)]
		public string Description { get; set; }

		[Column("qty", TypeName = "decimal(18,3)")]
		public decimal Qty { get; set; }

		[Column("uom")]
		[StringLength(30)]
		public string UoM { get; set; }

		[Column("unit_price", TypeName = "decimal(18,4)")]
		public decimal UnitPrice { get; set; }

		[Column("line_total", TypeName = "decimal(18,2)")]
		public decimal LineTotal { get; set; }

		[Column("delivery_date", TypeName = "date")]
		public DateTime? DeliveryDate { get; set; }

		[Required]
		[Column("status")]
		[StringLength(30)]
		public string Status { get; set; } = "ACTIVE";

		[Column("createdon")]
		public DateTime CreatedOn { get; set; } = DateTime.Now;

		[Column("updatedon")]
		public DateTime UpdatedOn { get; set; } = DateTime.Now;
		public bool IsDeleted { get; set; }
	}
}
