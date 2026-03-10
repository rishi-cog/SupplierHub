using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	public class ASNItem
	{
		[Key]
		public long ASNItemID { get; set; }
		public long ASNID { get; set; }
		public long POLineID { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal ShippedQty { get; set; }
		public string LotBatch { get; set; }
		public string SerialJSON { get; set; }
	}
}