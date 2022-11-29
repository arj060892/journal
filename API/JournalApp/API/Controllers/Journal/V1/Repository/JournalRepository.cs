using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Journal.V1.Repository
{
    public class JournalRepository : IJournalRepository
    {
        private readonly JournalContext journalContext;

        public JournalRepository(JournalContext journalContext)
        {
            this.journalContext = journalContext;
        }

        public Task<Entites.Journal> CreateAsync(Entites.Journal journal)
        {
            journalContext.Journals.Add(journal);
            journalContext.SaveChanges();

            return journalContext.Journals.FirstOrDefaultAsync(x => x.Id == journal.Id);

        }

        public Task DeleteAsync(int journalId)
        {
            Entites.Journal journal = journalContext.Journals.FirstOrDefault(x => x.Id == journalId);
            journalContext.Journals.Remove(journal);
            return journalContext.SaveChangesAsync();
        }


        public Task<List<Entites.Journal>> GetAllAsync()
        {
            return journalContext.Journals.ToListAsync();
        }

        public Task<Entites.Journal> GetAsync(int journalId)
        {
            return journalContext.Journals.FirstOrDefaultAsync(x => x.Id == journalId);
        }


        public Task<Entites.Journal> UpdateAsync(int journalId, Entites.Journal updatedJournal)
        {
            Entites.Journal journal = journalContext.Journals.FirstOrDefault(x => x.Id == journalId);
            journal = updatedJournal;
            journalContext.SaveChanges();

            return journalContext.Journals.FirstOrDefaultAsync(x => x.Id == journal.Id);

        }

        Task<List<Entites.Journal>> IJournalRepository.GetAllAsync()
        {
            return journalContext.Journals.ToListAsync();
        }
    }
}
