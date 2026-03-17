using System;

namespace SupplierHub.DTOs.InvoiceLineDTO
{
    public class InvoiceLineResponseDto
    {
        public long InvLineID { get; set; }
        public long InvoiceID { get; set; }
        public long? PoLineID { get; set; }
        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? LineTotal { get; set; }
        public string? TaxJson { get; set; }
        public string? MatchStatus { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
