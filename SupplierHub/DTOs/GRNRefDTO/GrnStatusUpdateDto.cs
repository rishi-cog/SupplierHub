using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.GrnRefDTO
{
    public class GrnStatusUpdateDto
    {
        [Required, MaxLength(30)]
        public string Status { get; set; } = string.Empty;
    }
}