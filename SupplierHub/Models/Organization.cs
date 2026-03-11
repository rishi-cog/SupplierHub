using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	[Table("organization")]
	public class Organization
	{
		[Key]
		public long OrgId { get; set; }

		[Required, MaxLength(200)]
		public string Name { get; set; }

		public string? AddressJson { get; set; }

		[MaxLength(50)]
		public string? TaxId { get; set; }

		[Required]
		public OrganizationStatus Status { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }
	}
}