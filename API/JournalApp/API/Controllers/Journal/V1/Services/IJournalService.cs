using API.Dtos;

namespace API.Controllers.Journal.V1.Services
{
    public interface IJournalService
    {
        Task<IList<JournalToReturnDto>> GetAllAsync();

        Task<JournalToReturnDto> GetAsync(int journalId);

        Task<JournalToReturnDto> CreateAsync(JournalToReturnDto journal);

        Task<JournalToReturnDto> UpdateAsync(int journalId, JournalToReturnDto journal);

        Task DeleteAsync(int journalId);
    }
}