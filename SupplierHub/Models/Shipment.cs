using System.ComponentModel.DataAnnotations;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	public class Shipment
	{
		[Key]
		public long ShipmentID { get; set; }
		public long POID { get; set; }
		public long SupplierID { get; set; }
		public DateTimeOffset ShipDate { get; set; }
		public string Carrier { get; set; }
		public string TrackingNo { get; set; }
		public ShipmentStatus Status { get; set; }
	}
}