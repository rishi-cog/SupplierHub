using System;

namespace SupplierHub.DTOs.MatchRefDTO
{
    public class MatchRefResponseDto
    {
        public long MatchID { get; set; }
        public long InvoiceID { get; set; }
        public long? PoID { get; set; }
        public long? GrnID { get; set; }
        public string? Result { get; set; }
        public string? Notes { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
