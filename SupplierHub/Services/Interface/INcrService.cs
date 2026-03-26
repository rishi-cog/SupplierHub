using System.Collections.Generic;
using System.Threading.Tasks;
using SupplierHub.DTOs.NcrDTO;

namespace SupplierHub.Services.Interface
{
    public interface INcrService
    {
        Task<NcrReadDto> CreateNcrAsync(NcrCreateDto dto);
        Task<List<NcrReadDto>> GetAllNcrsAsync();
        Task<NcrReadDto?> GetNcrByIdAsync(long id);
        Task<List<NcrReadDto>> GetNcrsByItemIdAsync(long grnItemId);
        Task<NcrReadDto?> UpdateNcrAsync(long id, NcrUpdateDto dto);
        Task<bool> DeleteNcrAsync(long id);
    }
}