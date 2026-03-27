using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;

namespace SupplierHub.Repositories
{
    public class GrnRepository : IGrnRepository
    {
        private readonly AppDbContext _db;
        public GrnRepository(AppDbContext db) { _db = db; }

        public Task<GrnRef?> GetGrnByIdAsync(long id) =>
            _db.GrnRefs.FirstOrDefaultAsync(x => x.GrnID == id && !x.IsDeleted);

        public Task<List<GrnRef>> GetAllGrnsAsync() =>
            _db.GrnRefs.Where(x => !x.IsDeleted).ToListAsync();

        public async Task<GrnRef> AddGrnAsync(GrnRef grn)
        {
            if (grn.AsnID.HasValue && grn.AsnID.Value == 0)
                grn.AsnID = null;

            if (grn.AsnID.HasValue)
            {
                var exists = await _db.Asns.AnyAsync(a => a.AsnID == grn.AsnID.Value);
                if (!exists)
                    throw new InvalidOperationException($"Asn with ID {grn.AsnID.Value} does not exist.");
            }

            grn.CreatedOn = DateTime.UtcNow;
            grn.UpdatedOn = DateTime.UtcNow;
            grn.IsDeleted = false;

            _db.GrnRefs.Add(grn);
            await _db.SaveChangesAsync();
            return grn;
        }

        public async Task<GrnRef?> UpdateGrnAsync(GrnRef grn)
        {
            _db.GrnRefs.Update(grn);
            await _db.SaveChangesAsync();
            return grn;
        }

        public async Task<bool> DeleteGrnAsync(long id)
        {
            var entity = await GetGrnByIdAsync(id);
            if (entity == null) return false;
            entity.IsDeleted = true;
            _db.GrnRefs.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}