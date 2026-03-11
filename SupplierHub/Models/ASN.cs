using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.Models
{
	public class ASN
	{
		[Key]
		public long ASNID { get; set; }

		[Required]
		public long ShipmentID { get; set; }

		[Required]
		[StringLength(100)]
		public string ASNNo { get; set; }

		[Required]
		public DateTime CreatedDate { get; set; }

		[Required]
		[StringLength(20)]
		public string Status { get; set; }

		// Navigation Properties
		public virtual Shipment Shipment { get; set; }

		public virtual ICollection<ASNItem> ASNItems { get; set; } = new List<ASNItem>();
	}
}