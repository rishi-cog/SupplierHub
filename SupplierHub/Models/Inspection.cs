using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	[Table("inspection")]
	public class Inspection
	{
		[Key]
		public int InspID { get; set; }

		[Required]
		public int GRNItemID { get; set; }

		[Required, MaxLength(10)]
		public string Result { get; set; }

		public string? FindingsJSON { get; set; }

		[Required]
		public int InspectorID { get; set; }

		[Required]
		public DateTime InspDate { get; set; }

		// Navigation
		[ForeignKey(nameof(GRNItemID))]
		public virtual GRNItemRef GRNItem { get; set; }
	}
}