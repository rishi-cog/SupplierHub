using System;
using System.ComponentModel.DataAnnotations;

<<<<<<< Updated upstream

namespace SupplierHub.DTOs.GrnRefDTO

=======
namespace SupplierHub.DTOs.GrnRefDTO


>>>>>>> Stashed changes
{
    public class GrnCreateDto
    {
        [Required]
        public long PoID { get; set; }

        public long? AsnID { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public long? ReceivedBy { get; set; }

        [Required, MaxLength(30)]
        public string Status { get; set; } = "Pending";
    }
}