using SupplierHub.Constants.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	public class ErpExportRef
	{
		[Key]
		[Column("erpref_id")]
		public long ErpRefId { get; set; }

		[Required]
		[Column("entity_type")]
		[StringLength (30)]
		public EntityType EntityType { get; set; }

		[Column("erpref_status")]
		[StringLength(500)]
		public string ? PayloadUri { get; set; }

		[Column("corelation_id")]
		[StringLength(100)]
		public string ? CorrelationId { get; set; }

		[Column("export_date")]
		public DateTime ? ExportDate { get; set; }

		[Required]
		[Column("status")]
		[StringLength(30)]
		public ErpExportRefStatus Status { get; set; } = ErpExportRefStatus.Queued;

		[Column("createdon")]
		public DateTime CreatedOn { get; set; } = DateTime.Now;

		[Column("updatedon")]
		public DateTime UpdatedOn { get; set; } = DateTime.Now;




	}
}
