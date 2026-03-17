using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.InspectionDTO
{
    public class GrnStatusUpdateDto
    {
        [Required, MaxLength(30)]
        public string Status { get; set; } = string.Empty;
    }
}