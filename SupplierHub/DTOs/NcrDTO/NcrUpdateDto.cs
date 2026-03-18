using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.NcrDTO
{
    public class NcrUpdateDto
    {
        [MaxLength(100)]
        public string? DefectType { get; set; }

        [MaxLength(20)]
        public string? Severity { get; set; }

        [Required, MaxLength(30)]
        public string Status { get; set; } = string.Empty;
    }
}