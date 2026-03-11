using System;
using System.ComponentModel.DataAnnotations;
using SupplierHub.Models.IAM;

namespace SupplierHub.Models
{
	public class ApprovalStep
	{
		[Key]
		public long StepID { get; set; }

		[Required]
		public long PRID { get; set; }

		[Required]
		public long ApproverID { get; set; }

		[Required]
		[StringLength(20)]
		public string Decision { get; set; }

		public DateTime? DecisionDate { get; set; }

		[StringLength(500)]
		public string Remarks { get; set; }

		// Navigation Properties
		public virtual Requisition Requisition { get; set; }

		public virtual User Approver { get; set; }
	}
}