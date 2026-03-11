using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.Models
{
	public class ASNItem
	{
		[Key]
		public long ASNItemID { get; set; }

		[Required]
		public long ASNID { get; set; }

		[Required]
		public long POLineID { get; set; }

		[Required]
		public decimal ShippedQty { get; set; }

		[StringLength(100)]
		public string LotBatch { get; set; }

		[StringLength(int.MaxValue)]
		public string SerialJSON { get; set; }

		[StringLength(500)]
		public string Notes { get; set; }

		// Navigation Properties
		public virtual ASN ASN { get; set; }

		public virtual POLine POLine { get; set; }
	}
}