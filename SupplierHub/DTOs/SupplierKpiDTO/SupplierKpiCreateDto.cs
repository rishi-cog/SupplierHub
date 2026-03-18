using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.SupplierKpiDTO
{

    public class SupplierKpiCreateDto
    {
        [Required]
        public long SupplierID { get; set; }

        [Required, MaxLength(20)]
        public string Period { get; set; } = string.Empty;

        public decimal? NcrRatePpm { get; set; }
        public decimal? AvgAckTimeHrs { get; set; }
        public decimal? PriceAdherencePct { get; set; }
        public decimal? Score { get; set; }

        public DateTime? GeneratedDate { get; set; } = DateTime.UtcNow;

        [Required, MaxLength(30)]
        public string Status { get; set; } = "Draft";
    }
}