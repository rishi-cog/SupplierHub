using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.GrnItemRefDTO
{
    public class GrnItemUpdateDto
    {
        public decimal? ReceivedQty { get; set; }
        public decimal? AcceptedQty { get; set; }
        public decimal? RejectedQty { get; set; }

        [MaxLength(200)]
        public string? Reason { get; set; }

        [Required, MaxLength(30)]
        public string Status { get; set; } = string.Empty;
    }
}