using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants.Enum;

namespace SupplierHub.Models
{
	[Table("po_ack")]
	public class PoAck
	{
		[Key]
		[Column("pocfm_id")]
		public long PoCfmId { get; set; }

		[Required]
		[Column("po_id")]
		public long PoId { get; set; }

		[ForeignKey("PoId")]
		public virtual PurchaseOrder PurchaseOrder { get; set; }

		[Required]
		[Column("supplier_id")]
		public long SupplierId { get; set; }

		[Column("acknowledge_date")]
		public DateTime? AcknowledgeDate { get; set; }

		[Column("decision")]
		[StringLength(30)]
		public PoAckDecision Decision { get; set; } = PoAckDecision.Accept;

		[Column("counternotes")]
		[StringLength(500)]
		public string CounterNotes { get; set; }

		[Required]
		[Column("status")]
		[StringLength(30)]
		public PoAckStatus Status { get; set; } = PoAckStatus.ACTIVE;

		[Column("createdon")]
		public DateTime CreatedOn { get; set; } = DateTime.Now;

		[Column("updatedon")]
		public DateTime UpdatedOn { get; set; } = DateTime.Now;
	}
}
