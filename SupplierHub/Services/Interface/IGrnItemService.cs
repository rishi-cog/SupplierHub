using System.Collections.Generic;
using System.Threading.Tasks;
using SupplierHub.DTOs.GrnItemRefDTO;

namespace SupplierHub.Services.Interface
{
    public interface IGrnItemService
    {
        Task<GrnItemReadDto> AddGrnItemAsync(GrnItemCreateDto dto);
        Task<List<GrnItemReadDto>> GetAllGrnItemsAsync();
        Task<GrnItemReadDto?> GetGrnItemByIdAsync(long id);
        Task<List<GrnItemReadDto>> GetGrnItemsByGrnIdAsync(long grnId);
        Task<GrnItemReadDto?> UpdateGrnItemAsync(long id, GrnItemUpdateDto dto);
        Task<bool> DeleteGrnItemAsync(long id);
    }
}