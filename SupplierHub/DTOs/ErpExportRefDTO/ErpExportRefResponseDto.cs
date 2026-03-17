using System;

namespace SupplierHub.DTOs.ErpExportRefDTO
{
    public class ErpExportRefResponseDto
    {
        public long ErprefID { get; set; }
        public string EntityType { get; set; } = string.Empty;
        public string? PayloadUri { get; set; }
        public string? CorrelationID { get; set; }
        public DateTime? ExportDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
