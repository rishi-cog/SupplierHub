using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants.Enum;

namespace SupplierHub.Models
{
	public class SystemConfig
	{
		[Key]
		public int ConfigID { get; set; }
		[StringLength(100)]
		public string? Key { get; set; }
		
		public string? value {  get; set; }

		public Scope? Scope {  get; set; }
		public int UpdatedBy { get; set; }
		[ForeignKey(nameof(UpdatedBy))]
		public User? LastEditor { get; set; }
		public DateTime UpdatedDate { get; set; }

	}
}
