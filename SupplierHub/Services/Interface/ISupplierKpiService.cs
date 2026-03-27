using SupplierHub.DTOs.SupplierKpiDTO;

namespace SupplierHub.Services.Interface
{
    public interface ISupplierKpiService
    {
        Task<SupplierKpiReadDto> CreateKpiAsync(SupplierKpiCreateDto dto);
        Task<List<SupplierKpiReadDto>> GetAllKpisAsync();
        Task<SupplierKpiReadDto?> GetKpiByIdAsync(long id);
        Task<List<SupplierKpiReadDto>> GetKpisBySupplierAsync(long supplierId);
        Task<SupplierKpiReadDto?> UpdateKpiAsync(long id, SupplierKpiUpdateDto dto);
        Task<bool> DeleteKpiAsync(long id);
    }
}