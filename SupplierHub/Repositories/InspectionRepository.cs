using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;

namespace SupplierHub.Repositories
{
    public class InspectionRepository : IInspectionRepository
    {
        private readonly AppDbContext _db;
        public InspectionRepository(AppDbContext db) { _db = db; }

        public Task<Inspection?> GetInspectionByIdAsync(long id) =>
            _db.Inspections.FirstOrDefaultAsync(x => x.InspID == id && !x.IsDeleted);

        public Task<List<Inspection>> GetAllInspectionsAsync() =>
            _db.Inspections.Where(x => !x.IsDeleted).ToListAsync();

        public Task<List<Inspection>> GetInspectionsByItemIdAsync(long grnItemId) =>
            _db.Inspections.Where(x => x.GrnItemID == grnItemId && !x.IsDeleted).ToListAsync();

        public async Task<Inspection> AddInspectionAsync(Inspection inspection)
        {
            _db.Inspections.Add(inspection);
            await _db.SaveChangesAsync();
            return inspection;
        }

        public async Task<Inspection?> UpdateInspectionAsync(Inspection inspection)
        {
            _db.Inspections.Update(inspection);
            await _db.SaveChangesAsync();
            return inspection;
        }

        public async Task<bool> DeleteInspectionAsync(long id)
        {
            var entity = await GetInspectionByIdAsync(id);
            if (entity == null) return false;
            entity.IsDeleted = true;
            _db.Inspections.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}