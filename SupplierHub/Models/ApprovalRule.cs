using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants.Enum;

namespace SupplierHub.Models
{
	[Table("approval_rule")]
	public class ApprovalRule
	{
		[Key]
		public int? RuleID { get; set; }

		[MaxLength(20)]
		public string? Scope { get; set; }

		public string? ExpressionJSON { get; set; }

		[Required]
		public RuleSeverity Severity { get; set; }

		[Required]
		public bool Status { get; set; } // default handled in config
	}
}