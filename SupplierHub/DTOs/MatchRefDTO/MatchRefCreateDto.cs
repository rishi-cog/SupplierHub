using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.MatchRefDTO
{
    public class MatchRefCreateDto
    {
        [Required]
        public long InvoiceID { get; set; }

        public long? PoID { get; set; }

        public long? GrnID { get; set; }

        [StringLength(20)]
        public string? Result { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        [StringLength(30)]
        public string? Status { get; set; }
    }
}
