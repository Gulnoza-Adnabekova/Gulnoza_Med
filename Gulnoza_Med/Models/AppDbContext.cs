using Microsoft.EntityFrameworkCore;

namespace Gulnoza_Med.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Fields> Fields { get; set; }
    }
}
