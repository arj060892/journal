using API.Controllers.Journal.V1.Services;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Journal.V1
{
    public class JournalController : BaseController
    {
        private readonly IJournalService journalService;

        public JournalController(IJournalService journalService)
        {
            this.journalService = journalService;
        }

        [HttpGet("GetAll")]
        public ActionResult<IList<Entites.Journal>> GetAll()
        {
            return Ok(journalService.GetAllAsync());
        }

        [HttpGet("{journalId}")]
        public ActionResult<IList<Entites.Journal>> Get(int journalId)
        {
            return Ok(journalService.GetAsync(journalId));
        }

        [HttpPut("{journalId}")]
        public ActionResult<IList<Entites.Journal>> Update(int journalId, JournalToReturnDto journal)
        {
            return Ok(journalService.UpdateAsync(journalId, journal));
        }

        [HttpPost]
        public ActionResult<IList<Entites.Journal>> Create(JournalToReturnDto journal)
        {
            return Ok(journalService.CreateAsync(journal));
        }

    }
}
