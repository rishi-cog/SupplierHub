using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	[Table("catalog_item")]
	public class CatalogItem
	{
		[Key]
		public long CatItemId { get; set; }

		[Required]
		public long CatalogId { get; set; }

		[Required]
		public long ItemId { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		[Required, MaxLength(10)]
		public string Currency { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal? MinOrderQty { get; set; }

		public string? PriceBreaksJson { get; set; }

		[Required]
		public CatalogItemStatus Status { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }

		public bool IsDeleted { get; set; }  // default -> false

		// Navigation
		[ForeignKey(nameof(CatalogId))]
		public virtual Catalog Catalog { get; set; }

		[ForeignKey(nameof(ItemId))]
		public virtual Item Item { get; set; }
	}
}