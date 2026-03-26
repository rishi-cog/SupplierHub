using System.Collections.Generic;
using System.Threading.Tasks;
using SupplierHub.Models;

namespace SupplierHub.Repositories.Interface
{
    public interface IInspectionRepository
    {
        Task<Inspection> AddInspectionAsync(Inspection inspection);
        Task<List<Inspection>> GetAllInspectionsAsync();
        Task<Inspection?> GetInspectionByIdAsync(long id);
        Task<List<Inspection>> GetInspectionsByItemIdAsync(long grnItemId);
        Task<Inspection?> UpdateInspectionAsync(Inspection inspection);
        Task<bool> DeleteInspectionAsync(long id);
    }
}