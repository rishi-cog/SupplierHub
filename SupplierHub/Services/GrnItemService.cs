using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;
using SupplierHub.Services.Interface;
using SupplierHub.DTOs.GrnItemRefDTO;

namespace SupplierHub.Services
{
    public class GrnItemService : IGrnItemService
    {
        private readonly IGrnItemRepository _repo;
        private readonly IMapper _mapper;

        public GrnItemService(IGrnItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GrnItemReadDto> AddGrnItemAsync(GrnItemCreateDto dto)
        {
            var entity = _mapper.Map<GrnItemRef>(dto);
            var saved = await _repo.AddGrnItemAsync(entity);
            return _mapper.Map<GrnItemReadDto>(saved);
        }

        public async Task<List<GrnItemReadDto>> GetAllGrnItemsAsync() =>
            _mapper.Map<List<GrnItemReadDto>>(await _repo.GetAllGrnItemsAsync());

        public async Task<GrnItemReadDto?> GetGrnItemByIdAsync(long id)
        {
            var entity = await _repo.GetGrnItemByIdAsync(id);
            return entity == null ? null : _mapper.Map<GrnItemReadDto>(entity);
        }

        public async Task<List<GrnItemReadDto>> GetGrnItemsByGrnIdAsync(long grnId)
        {
            var items = await _repo.GetItemsByGrnIdAsync(grnId);
            return _mapper.Map<List<GrnItemReadDto>>(items);
        }

        public async Task<GrnItemReadDto?> UpdateGrnItemAsync(long id, GrnItemUpdateDto dto)
        {
            var existing = await _repo.GetGrnItemByIdAsync(id);
            if (existing == null) return null;
            _mapper.Map(dto, existing);
            var updated = await _repo.UpdateGrnItemAsync(existing);
            return _mapper.Map<GrnItemReadDto>(updated);
        }

        public async Task<bool> DeleteGrnItemAsync(long id) => await _repo.DeleteGrnItemAsync(id);
    }
}