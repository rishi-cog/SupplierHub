using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	public class ApprovalStep
	{
		[Key]
		public long StepID { get; set; }
		public long PRID { get; set; }
		[ForeignKey("PRID")]
		public virtual Requisition Requisition { get; set; }

		public long ApproverID { get; set; }
		[ForeignKey("ApproverID")]
		public ApprovalDecision Decision { get; set; } = ApprovalDecision.Pending;
		public DateTimeOffset? DecisionDate { get; set; }
		public string Remarks { get; set; }
	}
}