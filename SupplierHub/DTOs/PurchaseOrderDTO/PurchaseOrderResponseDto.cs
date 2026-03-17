using System;

namespace SupplierHub.DTOs.PurchaseOrderDTO
{
    public class PurchaseOrderResponseDto
    {
        public long PoID { get; set; }
        public long OrgID { get; set; }
        public long SupplierID { get; set; }
        public DateTime? PoDate { get; set; }
        public string? Currency { get; set; }
        public string? Incoterms { get; set; }
        public string? PaymentTerms { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
