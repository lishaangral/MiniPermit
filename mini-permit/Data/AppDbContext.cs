using Microsoft.EntityFrameworkCore;
using MiniPermit.Models;

namespace MiniPermit.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Permit> Permits => Set<Permit>();
    }
}
