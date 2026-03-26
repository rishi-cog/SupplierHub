using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;
using SupplierHub.Services.Interface;
using SupplierHub.DTOs.ScorecardDTO;

namespace SupplierHub.Services
{
    public class ScorecardService : IScorecardService
    {
        private readonly IScorecardRepository _repo;
        private readonly IMapper _mapper;

        public ScorecardService(IScorecardRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ScorecardReadDto> CreateScorecardAsync(ScorecardCreateDto dto)
        {
            var entity = _mapper.Map<Scorecard>(dto);
            var saved = await _repo.AddScorecardAsync(entity);
            return _mapper.Map<ScorecardReadDto>(saved);
        }

        public async Task<List<ScorecardReadDto>> GetAllScorecardsAsync()
        {
            var entities = await _repo.GetAllScorecardsAsync();
            return _mapper.Map<List<ScorecardReadDto>>(entities);
        }

        public async Task<ScorecardReadDto?> GetScorecardByIdAsync(long id)
        {
            var entity = await _repo.GetScorecardByIdAsync(id);
            return entity == null ? null : _mapper.Map<ScorecardReadDto>(entity);
        }

        public async Task<List<ScorecardReadDto>> GetScorecardsBySupplierAsync(long supplierId)
        {
            var entities = await _repo.GetScorecardsBySupplierIdAsync(supplierId);
            return _mapper.Map<List<ScorecardReadDto>>(entities);
        }

        public async Task<ScorecardReadDto?> UpdateScorecardAsync(long id, ScorecardUpdateDto dto)
        {
            var existing = await _repo.GetScorecardByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            var updated = await _repo.UpdateScorecardAsync(existing);
            return _mapper.Map<ScorecardReadDto>(updated);
        }

        public async Task<bool> DeleteScorecardAsync(long id) =>
            await _repo.DeleteScorecardAsync(id);
    }
}