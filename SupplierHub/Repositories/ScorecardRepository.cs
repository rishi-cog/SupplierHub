using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;

namespace SupplierHub.Repositories
{
    public class ScorecardRepository : IScorecardRepository
    {
        private readonly AppDbContext _db;

        public ScorecardRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Scorecard> AddScorecardAsync(Scorecard scorecard)
        {
            _db.Scorecards.Add(scorecard);
            await _db.SaveChangesAsync();
            return scorecard;
        }

        public Task<List<Scorecard>> GetAllScorecardsAsync() =>
            _db.Scorecards.Where(x => !x.IsDeleted).ToListAsync();

        public Task<Scorecard?> GetScorecardByIdAsync(long id) =>
            _db.Scorecards.FirstOrDefaultAsync(x => x.ScorecardID == id && !x.IsDeleted);

        public Task<List<Scorecard>> GetScorecardsBySupplierIdAsync(long supplierId) =>
            _db.Scorecards.Where(x => x.SupplierID == supplierId && !x.IsDeleted).ToListAsync();

        public async Task<Scorecard?> UpdateScorecardAsync(Scorecard scorecard)
        {
            _db.Scorecards.Update(scorecard);
            await _db.SaveChangesAsync();
            return scorecard;
        }

        public async Task<bool> DeleteScorecardAsync(long id)
        {
            var scorecard = await GetScorecardByIdAsync(id);
            if (scorecard == null) return false;

            scorecard.IsDeleted = true; // Soft Delete
            _db.Scorecards.Update(scorecard);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}