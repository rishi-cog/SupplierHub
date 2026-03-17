using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.ErpExportRefDTO
{
    public class ErpExportRefUpdateDto
    {
        [Required]
        public long ErprefID { get; set; }

        [Required]
        [StringLength(30)]
        public string EntityType { get; set; } = string.Empty;

        [StringLength(500)]
        public string? PayloadUri { get; set; }

        [StringLength(100)]
        public string? CorrelationID { get; set; }

        public DateTime? ExportDate { get; set; }

        [StringLength(30)]
        public string? Status { get; set; }
    }
}
