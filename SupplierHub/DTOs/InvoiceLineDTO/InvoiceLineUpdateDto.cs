using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.InvoiceLineDTO
{
    public class InvoiceLineUpdateDto
    {
        [Required]
        public long InvLineID { get; set; }

        [Required]
        public long InvoiceID { get; set; }

        public long? PoLineID { get; set; }

        public decimal? Qty { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? LineTotal { get; set; }

        public string? TaxJson { get; set; }

        [StringLength(20)]
        public string? MatchStatus { get; set; }
    }
}
