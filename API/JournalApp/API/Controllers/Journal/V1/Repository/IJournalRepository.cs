namespace API.Controllers.Journal.V1.Repository
{
    public interface IJournalRepository
    {
        Task<List<Entites.Journal>> GetAllAsync();
        Task<Entites.Journal> GetAsync(int journalId);

        Task<Entites.Journal> CreateAsync(Entites.Journal journal);

        Task<Entites.Journal> UpdateAsync(int journalId, Entites.Journal journal);

        Task DeleteAsync(int journalId);
    }
}
