using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	[Table("scorecard")]
	public class Scorecard
	{
		[Key]
		public int ScorecardID { get; set; }

		[Required]
		public int SupplierID { get; set; }

		[Required, MinLength(7), MaxLength(7)]
		public string Period { get; set; }

		public string? MetricsJSON { get; set; }

		public int? Rank { get; set; }

		[MaxLength(500)]
		public string? Notes { get; set; }
	}
}