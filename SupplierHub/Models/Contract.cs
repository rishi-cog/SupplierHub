using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	[Table("contract")]
	public class Contract
	{
		[Key]
		public long ContractId { get; set; }

		[Required]
		public long SupplierId { get; set; }

		public long? ItemId { get; set; }

		public string? TermsJson { get; set; }

		[Column(TypeName = "decimal(18,4)")]
		public decimal? Rate { get; set; }

		[MaxLength(10)]
		public string? Currency { get; set; }

		public DateOnly? ValidFrom { get; set; }
		public DateOnly? ValidTo { get; set; }

		[Required]
		public ContractStatus Status { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }

		// Navigation
		[ForeignKey(nameof(SupplierId))]
		public virtual Supplier Supplier { get; set; }

		[ForeignKey(nameof(ItemId))]
		public virtual Item? Item { get; set; }
	}
}