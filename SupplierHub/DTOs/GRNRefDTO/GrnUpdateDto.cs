using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.InspectionDTO
{
    public class GrnUpdateDto
    {
        [Required]
        public long PoID { get; set; }

        public long? AsnID { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public long? ReceivedBy { get; set; }

        [Required, MaxLength(30)]
        public string Status { get; set; } = string.Empty;
    }
}