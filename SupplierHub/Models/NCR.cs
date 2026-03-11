using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	[Table("ncr")]
	public class NCR
	{
		[Key]
		public int NCRID { get; set; }

		[Required]
		public int GRNItemID { get; set; }

		[Required, MaxLength(100)]
		public string DefectType { get; set; }

		[Required, MaxLength(20)]
		public string Severity { get; set; }

		[Required, MaxLength(20)]
		public string Disposition { get; set; }

		[MaxLength(500)]
		public string? Notes { get; set; }

		[Required, MaxLength(20)]
		public string Status { get; set; }

		// Navigation
		[ForeignKey(nameof(GRNItemID))]
		public virtual GRNItemRef GRNItem { get; set; }
	}
}