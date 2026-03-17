using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.InvoiceDTO
{
    public class InvoiceCreateDto
    {
        [Required]
        public long SupplierID { get; set; }

        public long? PoID { get; set; }

        [StringLength(100)]
        public string? InvoiceNo { get; set; }

        public DateTime? InvoiceDate { get; set; }

        [StringLength(10)]
        public string? Currency { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? TaxJson { get; set; }

        [StringLength(30)]
        public string? Status { get; set; }
    }
}
