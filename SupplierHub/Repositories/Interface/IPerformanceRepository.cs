using SupplierHub.Models;

namespace SupplierHub.Repositories.Interface
{
    public interface IPerformanceRepository
    {
        // KPI
        Task<SupplierKpi?> GetKpiByIdAsync(long id);
        Task<List<SupplierKpi>> GetKpisBySupplierIdAsync(long supplierId);
        Task<SupplierKpi> AddKpiAsync(SupplierKpi kpi);
        Task<SupplierKpi?> UpdateKpiAsync(SupplierKpi kpi);

        // Scorecard
        Task<Scorecard?> GetScorecardByIdAsync(long id);
        Task<List<Scorecard>> GetScorecardsBySupplierIdAsync(long supplierId);
        Task<Scorecard> AddScorecardAsync(Scorecard scorecard);
        Task<Scorecard?> UpdateScorecardAsync(Scorecard scorecard);
    }
}