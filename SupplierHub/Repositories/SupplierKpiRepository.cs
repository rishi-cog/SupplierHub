using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;

namespace SupplierHub.Repositories
{
    public class SupplierKpiRepository : ISupplierKpiRepository
    {
        private readonly AppDbContext _db;

        public SupplierKpiRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<SupplierKpi> AddKpiAsync(SupplierKpi kpi)
        {
            _db.SupplierKpis.Add(kpi);
            await _db.SaveChangesAsync();
            return kpi;
        }

        public Task<List<SupplierKpi>> GetAllKpisAsync() =>
            _db.SupplierKpis.Where(x => !x.IsDeleted).ToListAsync();

        public Task<SupplierKpi?> GetKpiByIdAsync(long id) =>
            _db.SupplierKpis.FirstOrDefaultAsync(x => x.KpiID == id && !x.IsDeleted);

        public Task<List<SupplierKpi>> GetKpisBySupplierIdAsync(long supplierId) =>
            _db.SupplierKpis.Where(x => x.SupplierID == supplierId && !x.IsDeleted).ToListAsync();

        public async Task<SupplierKpi?> UpdateKpiAsync(SupplierKpi kpi)
        {
            _db.SupplierKpis.Update(kpi);
            await _db.SaveChangesAsync();
            return kpi;
        }

        public async Task<bool> DeleteKpiAsync(long id)
        {
            var kpi = await GetKpiByIdAsync(id);
            if (kpi == null) return false;

            kpi.IsDeleted = true; // Soft Delete
            _db.SupplierKpis.Update(kpi);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}