using System.Collections.Generic;
using System.Threading.Tasks;
using SupplierHub.Models;

namespace SupplierHub.Repositories.Interface
{
    public interface INcrRepository
    {
        Task<Ncr> AddNcrAsync(Ncr ncr);
        Task<List<Ncr>> GetAllNcrsAsync();
        Task<Ncr?> GetNcrByIdAsync(long id);
        Task<List<Ncr>> GetNcrsByItemIdAsync(long grnItemId);
        Task<Ncr?> UpdateNcrAsync(Ncr ncr);
        Task<bool> DeleteNcrAsync(long id);
    }
}