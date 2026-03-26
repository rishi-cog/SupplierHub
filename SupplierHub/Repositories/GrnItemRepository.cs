using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;

namespace SupplierHub.Repositories
{
    public class GrnItemRepository : IGrnItemRepository
    {
        private readonly AppDbContext _db;
        public GrnItemRepository(AppDbContext db) { _db = db; }

        public Task<GrnItemRef?> GetGrnItemByIdAsync(long id) =>
            _db.GrnItemRefs.FirstOrDefaultAsync(x => x.GrnItemID == id && !x.IsDeleted);

        public Task<List<GrnItemRef>> GetAllGrnItemsAsync() =>
            _db.GrnItemRefs.Where(x => !x.IsDeleted).ToListAsync();

        public Task<List<GrnItemRef>> GetItemsByGrnIdAsync(long grnId) =>
            _db.GrnItemRefs.Where(x => x.GrnID == grnId && !x.IsDeleted).ToListAsync();

        public async Task<GrnItemRef> AddGrnItemAsync(GrnItemRef item)
        {
            _db.GrnItemRefs.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<GrnItemRef?> UpdateGrnItemAsync(GrnItemRef item)
        {
            _db.GrnItemRefs.Update(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteGrnItemAsync(long id)
        {
            var entity = await GetGrnItemByIdAsync(id);
            if (entity == null) return false;
            entity.IsDeleted = true;
            _db.GrnItemRefs.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}