using System;

namespace SupplierHub.DTOs.PoRevisionDTO
{
    public class PoRevisionResponseDto
    {
        public long PorevID { get; set; }
        public long PoID { get; set; }
        public int RevisionNo { get; set; }
        public long? ChangedBy { get; set; }
        public string? ChangelogJson { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
