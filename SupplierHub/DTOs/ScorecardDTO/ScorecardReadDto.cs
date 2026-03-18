using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.ScorecardDTO
{

    public class ScorecardReadDto
    {
        public long ScorecardID { get; set; }
        public long SupplierID { get; set; }
        public string Period { get; set; } = string.Empty;
        public string? MetricsJson { get; set; }
        public int? Rank { get; set; }
        public string? Notes { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}