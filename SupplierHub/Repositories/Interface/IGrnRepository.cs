using System.Collections.Generic;
using System.Threading.Tasks;
using SupplierHub.Models;

namespace SupplierHub.Repositories.Interface
{
    public interface IGrnRepository
    {
        Task<GrnRef> AddGrnAsync(GrnRef grn);
        Task<List<GrnRef>> GetAllGrnsAsync();
        Task<GrnRef?> GetGrnByIdAsync(long id);
        Task<GrnRef?> UpdateGrnAsync(GrnRef grn);
        Task<bool> DeleteGrnAsync(long id);
    }
}