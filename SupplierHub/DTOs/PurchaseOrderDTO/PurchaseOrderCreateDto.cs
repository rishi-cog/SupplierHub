using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.PurchaseOrderDTO
{
    public class PurchaseOrderCreateDto
    {
        [Required]
        public long OrgID { get; set; }

        [Required]
        public long SupplierID { get; set; }

        public DateTime? PoDate { get; set; }

        [MaxLength(10)]
        public string? Currency { get; set; }

        [MaxLength(50)]
        public string? Incoterms { get; set; }

        [MaxLength(100)]
        public string? PaymentTerms { get; set; }

        [Required, MaxLength(50)]
        public string Status { get; set; } = string.Empty;
    }
}
