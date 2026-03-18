using SupplierHub.DTOs.SupplierKpiDTO;
using SupplierHub.DTOs.ScorecardDTO;

namespace SupplierHub.Services.Interface
{
    public interface IPerformanceService
    {
        // KPI Logic
        Task<List<SupplierKpiReadDto>> GetKpisBySupplierAsync(long supplierId);
        Task<SupplierKpiReadDto> CreateKpiAsync(SupplierKpiCreateDto dto);
        Task<SupplierKpiReadDto?> UpdateKpiAsync(long id, SupplierKpiUpdateDto dto);

        // Scorecard Logic
        Task<List<ScorecardReadDto>> GetScorecardsBySupplierAsync(long supplierId);
        Task<ScorecardReadDto> CreateScorecardAsync(ScorecardCreateDto dto);
        Task<ScorecardReadDto?> UpdateScorecardAsync(long id, ScorecardUpdateDto dto);
    }
}