using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	public class Requisition
	{
		[Key]
		public long PRID { get; set; }
		public long RequesterID { get; set; }
		[ForeignKey("RequesterID")]
		public virtual User User { get; set; }
		public long OrgID { get; set; }
		[StringLength(100)]
		[ForeignKey("OrgID")]
		public string CostCenter { get; set; }
		public string Justification { get; set; }
		public DateTimeOffset RequestedDate { get; set; } = DateTimeOffset.Now;
		public DateTimeOffset? NeededByDate { get; set; }
		public RequisitionStatus Status { get; set; } = RequisitionStatus.Draft;

		// Navigation Properties
		public virtual ICollection<PRLine> PRLines { get; set; }
		public virtual ICollection<ApprovalStep> ApprovalSteps { get; set; }
	}
}