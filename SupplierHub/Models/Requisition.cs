using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	public class Requisition
	{
		[Key]
		public long PRID { get; set; }

		[Required]
		public long RequesterID { get; set; }

		[Required]
		public long OrgID { get; set; }

		[StringLength(100)]
		public string? CostCenter { get; set; }

		[StringLength(int.MaxValue)]
		public string? Justification { get; set; }

		[Required]
		public DateTime RequestedDate { get; set; }

		public DateTime? NeededByDate { get; set; }

		[Required]
		public RequisitionStatus Status { get; set; }

		// Navigation Properties
		public virtual User Requester { get; set; }

		public virtual Organization Organization { get; set; }

		public virtual ICollection<PRLine> PRLines { get; set; } = new List<PRLine>();

		public virtual ICollection<ApprovalStep> ApprovalSteps { get; set; } = new List<ApprovalStep>();

		public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
	}
}