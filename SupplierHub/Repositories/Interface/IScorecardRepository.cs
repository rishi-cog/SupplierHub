using System.Collections.Generic;
using System.Threading.Tasks;
using SupplierHub.Models;

namespace SupplierHub.Repositories.Interface
{
    public interface IScorecardRepository
    {
        Task<Scorecard> AddScorecardAsync(Scorecard scorecard);
        Task<List<Scorecard>> GetAllScorecardsAsync();
        Task<Scorecard?> GetScorecardByIdAsync(long id);
        Task<List<Scorecard>> GetScorecardsBySupplierIdAsync(long supplierId);
        Task<Scorecard?> UpdateScorecardAsync(Scorecard scorecard);
        Task<bool> DeleteScorecardAsync(long id);
    }
}