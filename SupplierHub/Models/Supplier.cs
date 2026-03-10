using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	[Table("Supplier")]
	public class Supplier
	{
		public long SupplierId { get; set; }
		public string LegalName { get; set; }
		public string DunsOrRegNo { get; set; }
		public string TaxId { get; set; }

		// JSON column → in API models usually represented as string or strongly typed object
		public string BankInfoJson { get; set; }

		public long? PrimaryContactId { get; set; }

		public string Status { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime UpdatedOn { get; set; }
	}
}
