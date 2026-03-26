using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;
using SupplierHub.Services.Interface;
using SupplierHub.DTOs.InspectionDTO;

namespace SupplierHub.Services
{
    public class InspectionService : IInspectionService
    {
        private readonly IInspectionRepository _repo;
        private readonly IMapper _mapper;

        public InspectionService(IInspectionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<InspectionReadDto> CreateInspectionAsync(InspectionCreateDto dto)
        {
            var entity = _mapper.Map<Inspection>(dto);
            var saved = await _repo.AddInspectionAsync(entity);
            return _mapper.Map<InspectionReadDto>(saved);
        }

        public async Task<List<InspectionReadDto>> GetAllInspectionsAsync() =>
            _mapper.Map<List<InspectionReadDto>>(await _repo.GetAllInspectionsAsync());

        public async Task<InspectionReadDto?> GetInspectionByIdAsync(long id)
        {
            var entity = await _repo.GetInspectionByIdAsync(id);
            return entity == null ? null : _mapper.Map<InspectionReadDto>(entity);
        }

        public async Task<List<InspectionReadDto>> GetInspectionsByItemIdAsync(long grnItemId) =>
            _mapper.Map<List<InspectionReadDto>>(await _repo.GetInspectionsByItemIdAsync(grnItemId));

        public async Task<InspectionReadDto?> UpdateInspectionAsync(long id, InspectionUpdateDto dto)
        {
            var existing = await _repo.GetInspectionByIdAsync(id);
            if (existing == null) return null;
            _mapper.Map(dto, existing);
            var updated = await _repo.UpdateInspectionAsync(existing);
            return _mapper.Map<InspectionReadDto>(updated);
        }

        public async Task<bool> DeleteInspectionAsync(long id) => await _repo.DeleteInspectionAsync(id);
    }
}