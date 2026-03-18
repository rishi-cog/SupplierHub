using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.GrnItemRefDTO
{
    public class GrnItemReadDto
    {
        public long GrnItemID { get; set; }
        public long GrnID { get; set; }
        public long PoLineID { get; set; }
        public decimal? ReceivedQty { get; set; }
        public decimal? AcceptedQty { get; set; }
        public decimal? RejectedQty { get; set; }
        public string? Reason { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}