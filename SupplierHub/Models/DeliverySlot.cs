using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.Models
{
	public class DeliverySlot
	{
		[Key]
		public long SlotID { get; set; }

		[Required]
		public long SiteID { get; set; }

		[Required]
		public DateTime SlotDate { get; set; }

		[Required]
		public TimeSpan StartTime { get; set; }

		[Required]
		public TimeSpan EndTime { get; set; }

		[Required]
		public int Capacity { get; set; }

		[Required]
		[StringLength(20)]
		public string Status { get; set; }

		// Navigation Properties
		public virtual Site Site { get; set; }
	}
}