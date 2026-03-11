using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.Models
{
	public class Shipment
	{
		[Key]
		public long ShipmentID { get; set; }

		[Required]
		public long POID { get; set; }

		[Required]
		public long SupplierID { get; set; }

		[Required]
		public DateTime ShipDate { get; set; }

		[StringLength(100)]
		public string Carrier { get; set; }

		[StringLength(100)]
		public string TrackingNo { get; set; }

		[Required]
		[StringLength(20)]
		public string Status { get; set; }

		// Navigation Properties
		public virtual PurchaseOrder PurchaseOrder { get; set; }

		public virtual Supplier Supplier { get; set; }

		public virtual ICollection<ASN> ASNs { get; set; } = new List<ASN>();
	}
}