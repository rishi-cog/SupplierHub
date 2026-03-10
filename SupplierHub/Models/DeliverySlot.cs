using System.ComponentModel.DataAnnotations;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	public class DeliverySlot
	{
		[Key]
		public long SlotID { get; set; }
		public long SiteID { get; set; }
		public DateTime SlotDate { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }
		public int Capacity { get; set; }
		public SlotStatus Status { get; set; }
	}
}