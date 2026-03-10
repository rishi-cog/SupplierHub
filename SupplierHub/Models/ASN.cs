using System.ComponentModel.DataAnnotations;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	public class ASN
	{
		[Key]
		public long ASNID { get; set; }
		public long ShipmentID { get; set; }
		[Required, StringLength(100)]
		public string ASNNo { get; set; }
		public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
		public ASNStatus Status { get; set; }
	}
}