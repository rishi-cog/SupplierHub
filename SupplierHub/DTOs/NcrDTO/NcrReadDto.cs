using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.NcrDTO
{
    public class NcrReadDto
    {
        public long NcrID { get; set; }
        public long GrnItemID { get; set; }
        public string? DefectType { get; set; }
        public string? Severity { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}