using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SupplierHub.Models;

namespace SupplierHub.Models
{
	public class PRLine
	{
		[Key]
		public long PRLineID { get; set; }

		[Required]
		public long PRID { get; set; }

		[Required]
		public long ItemID { get; set; }

		[StringLength(int.MaxValue)]
		public string Description { get; set; }

		[Required]
		public decimal Qty { get; set; }

		[StringLength(20)]
		public string UoM { get; set; }

		[Required]
		public decimal TargetPrice { get; set; }

		[StringLength(3)]
		public string Currency { get; set; } = "USD";

		public long? SupplierPreferredID { get; set; }

		[StringLength(500)]
		public string Notes { get; set; }

		// Navigation Properties
		public virtual Requisition Requisition { get; set; }

		public virtual Item Item { get; set; }

		public virtual Supplier SupplierPreferred { get; set; }
	}
}