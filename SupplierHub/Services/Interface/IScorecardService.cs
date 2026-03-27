using SupplierHub.DTOs.ScorecardDTO;

namespace SupplierHub.Services.Interface
{
    public interface IScorecardService
    {
        Task<ScorecardReadDto> CreateScorecardAsync(ScorecardCreateDto dto);
        Task<List<ScorecardReadDto>> GetAllScorecardsAsync();
        Task<ScorecardReadDto?> GetScorecardByIdAsync(long id);
        Task<List<ScorecardReadDto>> GetScorecardsBySupplierAsync(long supplierId);
        Task<ScorecardReadDto?> UpdateScorecardAsync(long id, ScorecardUpdateDto dto);
        Task<bool> DeleteScorecardAsync(long id);
    }
}