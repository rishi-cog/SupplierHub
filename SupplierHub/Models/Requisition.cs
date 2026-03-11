using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	[Table("requisition")]
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

		public string? Justification { get; set; }

		[Required]
		public DateTimeOffset RequestedDate { get; set; }

		public DateTimeOffset? NeededByDate { get; set; }

		[Required]
		public RequisitionStatus Status { get; set; }
	}
}