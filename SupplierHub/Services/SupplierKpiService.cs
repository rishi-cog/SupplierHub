using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;
using SupplierHub.Services.Interface;
using SupplierHub.DTOs.SupplierKpiDTO;

namespace SupplierHub.Services
{
    public class SupplierKpiService : ISupplierKpiService
    {
        private readonly ISupplierKpiRepository _repo;
        private readonly IMapper _mapper;

        public SupplierKpiService(ISupplierKpiRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<SupplierKpiReadDto> CreateKpiAsync(SupplierKpiCreateDto dto)
        {
            var entity = _mapper.Map<SupplierKpi>(dto);
            var saved = await _repo.AddKpiAsync(entity);
            return _mapper.Map<SupplierKpiReadDto>(saved);
        }

        public async Task<List<SupplierKpiReadDto>> GetAllKpisAsync()
        {
            var entities = await _repo.GetAllKpisAsync();
            return _mapper.Map<List<SupplierKpiReadDto>>(entities);
        }

        public async Task<SupplierKpiReadDto?> GetKpiByIdAsync(long id)
        {
            var entity = await _repo.GetKpiByIdAsync(id);
            return entity == null ? null : _mapper.Map<SupplierKpiReadDto>(entity);
        }

        public async Task<List<SupplierKpiReadDto>> GetKpisBySupplierAsync(long supplierId)
        {
            var entities = await _repo.GetKpisBySupplierIdAsync(supplierId);
            return _mapper.Map<List<SupplierKpiReadDto>>(entities);
        }

        public async Task<SupplierKpiReadDto?> UpdateKpiAsync(long id, SupplierKpiUpdateDto dto)
        {
            var existing = await _repo.GetKpiByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            var updated = await _repo.UpdateKpiAsync(existing);
            return _mapper.Map<SupplierKpiReadDto>(updated);
        }

        public async Task<bool> DeleteKpiAsync(long id) =>
            await _repo.DeleteKpiAsync(id);
    }
}