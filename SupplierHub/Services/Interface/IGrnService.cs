using System.Collections.Generic;
using System.Threading.Tasks;
using SupplierHub.DTOs.GrnRefDTO;

namespace SupplierHub.Services.Interface
{
    public interface IGrnService
    {
        Task<GrnReadDto> CreateGrnAsync(GrnCreateDto dto);
        Task<List<GrnReadDto>> GetAllGrnsAsync();
        Task<GrnReadDto?> GetGrnByIdAsync(long id);
        Task<GrnReadDto?> UpdateGrnAsync(long id, GrnUpdateDto dto);
        Task<bool> DeleteGrnAsync(long id);
    }
}