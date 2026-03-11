using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	[Table("grn_ref")]
	public class GRNRef
	{
		[Key]
		public int GRNID { get; set; }

		[Required]
		public int POID { get; set; }

		public int? ASNID { get; set; }

		[Required]
		public DateTime ReceivedDate { get; set; }

		[Required, MaxLength(150)]
		public string ReceivedBy { get; set; }

		[Required, MaxLength(20)]
		public string Status { get; set; }

		// Navigation
		public virtual ICollection<GRNItemRef> Items { get; set; }
	}
}