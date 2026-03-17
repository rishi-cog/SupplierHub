using System;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace SupplierHub.DTOs.GrnRefDTO
=======
namespace SupplierHub.DTOs.GRNRefDTO
>>>>>>> eb1722ce27b7598596a49576b61ea83ff529f00a
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