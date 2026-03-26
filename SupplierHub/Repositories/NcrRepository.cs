using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;

namespace SupplierHub.Repositories
{
    public class NcrRepository : INcrRepository
    {
        private readonly AppDbContext _db;
        public NcrRepository(AppDbContext db) { _db = db; }

        public Task<Ncr?> GetNcrByIdAsync(long id) =>
            _db.Ncrs.FirstOrDefaultAsync(x => x.NcrID == id && !x.IsDeleted);

        public Task<List<Ncr>> GetAllNcrsAsync() =>
            _db.Ncrs.Where(x => !x.IsDeleted).ToListAsync();

        public Task<List<Ncr>> GetNcrsByItemIdAsync(long grnItemId) =>
            _db.Ncrs.Where(x => x.GrnItemID == grnItemId && !x.IsDeleted).ToListAsync();

        public async Task<Ncr> AddNcrAsync(Ncr ncr)
        {
            _db.Ncrs.Add(ncr);
            await _db.SaveChangesAsync();
            return ncr;
        }

        public async Task<Ncr?> UpdateNcrAsync(Ncr ncr)
        {
            _db.Ncrs.Update(ncr);
            await _db.SaveChangesAsync();
            return ncr;
        }

        public async Task<bool> DeleteNcrAsync(long id)
        {
            var entity = await GetNcrByIdAsync(id);
            if (entity == null) return false;
            entity.IsDeleted = true;
            _db.Ncrs.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}