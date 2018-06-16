using Microsoft.EntityFrameworkCore;

namespace f2e_week2_filter.Models
{
    public class KSContext : DbContext {
        public KSContext (DbContextOptions<KSContext> options) : base (options) {}
        
        public DbSet<Record> SenicSpots {get; set;}
    }
}