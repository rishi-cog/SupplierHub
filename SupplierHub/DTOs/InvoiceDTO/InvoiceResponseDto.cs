using System;

namespace SupplierHub.DTOs.InvoiceDTO
{
    public class InvoiceResponseDto
    {
        public long InvoiceID { get; set; }
        public long SupplierID { get; set; }
        public long? PoID { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Currency { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? TaxJson { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
