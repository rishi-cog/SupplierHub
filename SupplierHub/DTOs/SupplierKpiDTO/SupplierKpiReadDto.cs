using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.SupplierKpiDTO
{

    public class SupplierKpiReadDto
    {
        public long KpiID { get; set; }
        public long SupplierID { get; set; }
        public string Period { get; set; } = string.Empty; // e.g., "2024-Q1" or "2024-05"
        public decimal? NcrRatePpm { get; set; }
        public decimal? AvgAckTimeHrs { get; set; }
        public decimal? PriceAdherencePct { get; set; }
        public decimal? Score { get; set; }
        public DateTime? GeneratedDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}