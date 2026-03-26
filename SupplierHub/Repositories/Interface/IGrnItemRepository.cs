using System.Collections.Generic;
using System.Threading.Tasks;
using SupplierHub.Models;

namespace SupplierHub.Repositories.Interface
{
    public interface IGrnItemRepository
    {
        Task<GrnItemRef> AddGrnItemAsync(GrnItemRef item);
        Task<List<GrnItemRef>> GetAllGrnItemsAsync();
        Task<GrnItemRef?> GetGrnItemByIdAsync(long id);
        Task<List<GrnItemRef>> GetItemsByGrnIdAsync(long grnId);
        Task<GrnItemRef?> UpdateGrnItemAsync(GrnItemRef item);
        Task<bool> DeleteGrnItemAsync(long id);
    }
}