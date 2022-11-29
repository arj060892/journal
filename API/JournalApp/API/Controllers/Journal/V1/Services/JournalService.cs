using API.Controllers.Journal.V1.Repository;
using API.Dtos;
using AutoMapper;

namespace API.Controllers.Journal.V1.Services
{
    public class JournalService : IJournalService
    {
        private readonly IJournalRepository journalRepository;
        private readonly IMapper mapper;

        public JournalService(IJournalRepository journalRepository, IMapper mapper)
        {
            this.journalRepository = journalRepository;
            this.mapper = mapper;
        }
        public async Task<JournalToReturnDto> CreateAsync(JournalToReturnDto journal)
        {
            Entites.Journal newJournal = mapper.Map<Entites.Journal>(journal);
            newJournal.CreatedBy = 1;
            newJournal.CreatedOn = DateTime.Now;
            newJournal.ModifiedOn = DateTime.Now;

            newJournal = await journalRepository.CreateAsync(newJournal);
            return mapper.Map<JournalToReturnDto>(newJournal);
        }

        public async Task DeleteAsync(int journalId)
        {
            await journalRepository.DeleteAsync(journalId);
        }

        public async Task<JournalToReturnDto> GetAsync(int journalId)
        {
            Entites.Journal journal = await journalRepository.GetAsync(journalId);
            return mapper.Map<JournalToReturnDto>(journal);
        }

        public async Task<IList<JournalToReturnDto>> GetAllAsync()
        {
            List<Entites.Journal> journals = await journalRepository.GetAllAsync();
            return mapper.Map<IList<JournalToReturnDto>>(journals);
        }

        public async Task<JournalToReturnDto> UpdateAsync(int journalId, JournalToReturnDto journal)
        {

            Entites.Journal updatedJournal = mapper.Map<Entites.Journal>(journal);
            updatedJournal.ModifiedOn = DateTime.Now;

            updatedJournal = await journalRepository.UpdateAsync(journalId, updatedJournal);
            return mapper.Map<JournalToReturnDto>(updatedJournal);
        }

    }
}
