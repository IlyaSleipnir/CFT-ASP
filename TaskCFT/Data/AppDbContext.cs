using Microsoft.EntityFrameworkCore;
using TaskCFT.Models.Entities;

namespace TaskCFT.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<WorkRequest> WorkRequest { get; set; } = default!;
        public DbSet<Application> Application { get; set; } = default!;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
