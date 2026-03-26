using System.Collections.Generic;
using System.Threading.Tasks;
using SupplierHub.DTOs.InspectionDTO;

namespace SupplierHub.Services.Interface
{
    public interface IInspectionService
    {
        Task<InspectionReadDto> CreateInspectionAsync(InspectionCreateDto dto);
        Task<List<InspectionReadDto>> GetAllInspectionsAsync();
        Task<InspectionReadDto?> GetInspectionByIdAsync(long id);
        Task<List<InspectionReadDto>> GetInspectionsByItemIdAsync(long grnItemId);
        Task<InspectionReadDto?> UpdateInspectionAsync(long id, InspectionUpdateDto dto);
        Task<bool> DeleteInspectionAsync(long id);
    }
}