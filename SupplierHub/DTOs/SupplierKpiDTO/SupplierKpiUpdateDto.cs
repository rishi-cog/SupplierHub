using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.SupplierKpiDTO
{

    public class SupplierKpiUpdateDto
    {
        public decimal? NcrRatePpm { get; set; }
        public decimal? AvgAckTimeHrs { get; set; }
        public decimal? PriceAdherencePct { get; set; }
        public decimal? Score { get; set; }

        [Required, MaxLength(30)]
        public string Status { get; set; } = string.Empty;
    }
}