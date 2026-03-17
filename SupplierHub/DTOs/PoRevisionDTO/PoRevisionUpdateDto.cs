using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.PoRevisionDTO
{
    public class PoRevisionUpdateDto
    {
        [Required]
        public long PorevID { get; set; }

        [Required]
        public long PoID { get; set; }

        [Required]
        public int RevisionNo { get; set; }

        public long? ChangedBy { get; set; }

        public string? ChangelogJson { get; set; }

        public DateTime? ChangeDate { get; set; }

        [StringLength(30)]
        public string? Status { get; set; }
    }
}
