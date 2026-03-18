using SupplierHub.Models;

namespace SupplierHub.Repositories.Interface
{
    public interface IReceivingQualityRepository
    {
        // GRN Header
        Task<GrnRef?> GetGrnByIdAsync(long id);
        Task<List<GrnRef>> GetAllGrnsAsync();
        Task<GrnRef> AddGrnAsync(GrnRef grn);
        Task<GrnRef?> UpdateGrnAsync(GrnRef grn);

        // GRN Items
        Task<GrnItemRef?> GetGrnItemByIdAsync(long id);
        Task<List<GrnItemRef>> GetItemsByGrnIdAsync(long grnId);
        Task<GrnItemRef> AddGrnItemAsync(GrnItemRef item);
        Task<GrnItemRef?> UpdateGrnItemAsync(GrnItemRef item);

        // Inspection
        Task<Inspection?> GetInspectionByIdAsync(long id);
        Task<List<Inspection>> GetInspectionsByItemIdAsync(long grnItemId);
        Task<Inspection> AddInspectionAsync(Inspection inspection);
        Task<Inspection?> UpdateInspectionAsync(Inspection inspection);

        // NCR
        Task<Ncr?> GetNcrByIdAsync(long id);
        Task<List<Ncr>> GetNcrsByItemIdAsync(long grnItemId);
        Task<Ncr> AddNcrAsync(Ncr ncr);
        Task<Ncr?> UpdateNcrAsync(Ncr ncr);
    }
}