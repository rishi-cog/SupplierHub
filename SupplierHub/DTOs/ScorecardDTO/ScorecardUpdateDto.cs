using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.ScorecardDTO
{

    public class ScorecardUpdateDto
    {
        public string? MetricsJson { get; set; }
        public int? Rank { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }

        [Required, MaxLength(30)]
        public string Status { get; set; } = string.Empty;
    }
}