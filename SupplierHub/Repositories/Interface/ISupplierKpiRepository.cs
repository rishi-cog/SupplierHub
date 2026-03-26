using System.Collections.Generic;
using System.Threading.Tasks;
using SupplierHub.Models;

namespace SupplierHub.Repositories.Interface
{
    public interface ISupplierKpiRepository
    {
        Task<SupplierKpi> AddKpiAsync(SupplierKpi kpi);
        Task<List<SupplierKpi>> GetAllKpisAsync();
        Task<SupplierKpi?> GetKpiByIdAsync(long id);
        Task<List<SupplierKpi>> GetKpisBySupplierIdAsync(long supplierId);
        Task<SupplierKpi?> UpdateKpiAsync(SupplierKpi kpi);
        Task<bool> DeleteKpiAsync(long id);
    }
}