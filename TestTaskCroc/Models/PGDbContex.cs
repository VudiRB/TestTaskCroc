using Microsoft.EntityFrameworkCore;

namespace TestTaskCroc.Models
{
    public class PGDbContext: DbContext
    {
        public PGDbContext(DbContextOptions<PGDbContext> options) : base(options) { }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Trips> Trips { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
    }
}