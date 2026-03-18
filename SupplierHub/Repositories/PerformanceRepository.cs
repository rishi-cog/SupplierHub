using Microsoft.EntityFrameworkCore;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;

namespace SupplierHub.Repositories
{
    public class PerformanceRepository : IPerformanceRepository
    {
        private readonly AppDbContext _db;

        public PerformanceRepository(AppDbContext db)
        {
            _db = db;
        }

        // KPI Methods
        public Task<SupplierKpi?> GetKpiByIdAsync(long id) =>
            _db.SupplierKpis.FirstOrDefaultAsync(x => x.KpiID == id && !x.IsDeleted);

        public Task<List<SupplierKpi>> GetKpisBySupplierIdAsync(long supplierId) =>
            _db.SupplierKpis.Where(x => x.SupplierID == supplierId && !x.IsDeleted).ToListAsync();

        public async Task<SupplierKpi> AddKpiAsync(SupplierKpi kpi)
        {
            try
            {
                _db.SupplierKpis.Add(kpi);
                await _db.SaveChangesAsync();
                return kpi;
            }
            catch (DbUpdateException ex)
            {
                // Put a breakpoint on the line below to inspect 'innerMessage'
                // Or log it to your console/logger
                var innerMessage = ex.InnerException?.Message ?? ex.Message;

                // For now, let's throw it so you can see it clearly in your output
                throw new Exception($"Database save failed: {innerMessage}", ex);
            }
        }
        public async Task<SupplierKpi?> UpdateKpiAsync(SupplierKpi kpi)
        {
            _db.SupplierKpis.Update(kpi);
            await _db.SaveChangesAsync();
            return kpi;
        }

        // Scorecard Methods
        public Task<Scorecard?> GetScorecardByIdAsync(long id) =>
            _db.Scorecards.FirstOrDefaultAsync(x => x.ScorecardID == id && !x.IsDeleted);

        public Task<List<Scorecard>> GetScorecardsBySupplierIdAsync(long supplierId) =>
            _db.Scorecards.Where(x => x.SupplierID == supplierId && !x.IsDeleted).ToListAsync();

        public async Task<Scorecard> AddScorecardAsync(Scorecard scorecard)
        {
            _db.Scorecards.Add(scorecard);
            await _db.SaveChangesAsync();
            return scorecard;
        }

        public async Task<Scorecard?> UpdateScorecardAsync(Scorecard scorecard)
        {
            _db.Scorecards.Update(scorecard);
            await _db.SaveChangesAsync();
            return scorecard;
        }
    }
}