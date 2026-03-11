using SupplierHub.Constants.Enum;

namespace SupplierHub.Models
{
	public class ErpExportRef
	{
		public long ErpRefId { get; set; }
		public EntityType EntityType { get; set; }
		public string? PayloadUri { get; set; }
		public string? CorrelationId { get; set; }
		public DateTime? ExportDate { get; set; }
		public ErpExportRefStatus Status { get; set; } = ErpExportRefStatus.Queued;
		public DateTime CreatedOn { get; set; }
		public DateTime? UpdatedOn { get; set; }
		public bool IsDeleted { get; set; }
	}
}