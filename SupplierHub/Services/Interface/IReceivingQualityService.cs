using SupplierHub.DTOs.GrnRefDTO;
using SupplierHub.DTOs.GrnItemRefDTO;
using SupplierHub.DTOs.NcrDTO;
using SupplierHub.DTOs.InspectionDTO;

namespace SupplierHub.Services.Interface
{
    public interface IReceivingQualityService
    {
        // GRN Header
        Task<GrnReadDto?> GetGrnByIdAsync(long id);
        Task<List<GrnReadDto>> GetAllGrnsAsync();
        Task<GrnReadDto> CreateGrnAsync(GrnCreateDto dto);
        Task<GrnReadDto?> UpdateGrnAsync(long id, GrnUpdateDto dto);

        // GRN Items
        Task<List<GrnItemReadDto>> GetGrnItemsByGrnIdAsync(long grnId);
        Task<GrnItemReadDto> AddGrnItemAsync(GrnItemCreateDto dto);
        Task<GrnItemReadDto?> UpdateGrnItemAsync(long id, GrnItemUpdateDto dto);

        // Inspections
        Task<List<InspectionReadDto>> GetInspectionsByItemIdAsync(long grnItemId);
        Task<InspectionReadDto> CreateInspectionAsync(InspectionCreateDto dto);
        Task<InspectionReadDto?> UpdateInspectionAsync(long id, InspectionUpdateDto dto);

        // NCR (Non-Conformance)
        Task<List<NcrReadDto>> GetNcrsByItemIdAsync(long grnItemId);
        Task<NcrReadDto> CreateNcrAsync(NcrCreateDto dto);
        Task<NcrReadDto?> UpdateNcrAsync(long id, NcrUpdateDto dto);
    }
}