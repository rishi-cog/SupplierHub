using SupplierHub.Constants.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	[Table("po_revision")]
	public class PORevision
	{
		[Key]
		[Column("porev_id")]
		public long PoRevId { get; set; }

		[Required]
		[Column("po_id")]
		public long PoId { get; set; }

		[ForeignKey("PoId")]
		public virtual PurchaseOrder PurchaseOrder { get; set; }

		[Required]
		[Column("revision_no")]
		public int RevisionNo { get; set; }

		[Column("changed_by")]
		public long? ChangedBy { get; set; } // FK → app_user(user_id)

		[Column("changelog_json")]
		public string ChangelogJson { get; set; }
		[Column("change_date")]
		public DateTime ChangeDate { get; set; } = DateTime.Now;

		[Required]
		[Column("status")]
		[StringLength(30)]
		public PoRevisionStatus Status { get; set; } = PoRevisionStatus.Active;

		[Column("createdon")]
		public DateTime CreatedOn { get; set; } = DateTime.Now;

		[Column("updatedon")]
		public DateTime UpdatedOn { get; set; } = DateTime.Now;
	}
}