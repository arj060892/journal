using API.Entites;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class JournalContext : DbContext
    {
        public JournalContext(DbContextOptions<JournalContext> options) : base(options)
        {
        }

        public DbSet<Journal> Journals { get; set; }
    }
}
