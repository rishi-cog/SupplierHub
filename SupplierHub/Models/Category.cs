using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	[Table("category")]
	public class Category
	{
		[Key]
		public long CategoryId { get; set; }

		public long? ParentCategoryId { get; set; }

		[Required, MaxLength(200)]
		public string Name { get; set; }

		[Required]
		public CategoryStatus Status { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }

		// Navigation
		[ForeignKey(nameof(ParentCategoryId))]
		public virtual Category? ParentCategory { get; set; }

		public virtual ICollection<Category> SubCategories { get; set; }
		public virtual ICollection<Item> Items { get; set; }
	}
}