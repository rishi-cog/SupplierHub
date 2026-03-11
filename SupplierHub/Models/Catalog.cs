using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	[Table("catalog")]
	public class Catalog
	{
		[Key]
		public long CatalogId { get; set; }

		[Required]
		public long SupplierId { get; set; }

		[Required, MaxLength(200)]
		public string Name { get; set; }

		public DateOnly? ValidFrom { get; set; }
		public DateOnly? ValidTo { get; set; }

		[Required]
		public CatalogStatus Status { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }

		// Navigation
		[ForeignKey(nameof(SupplierId))]
		public virtual Supplier Supplier { get; set; }

		public virtual ICollection<CatalogItem> CatalogItems { get; set; }
	}
}