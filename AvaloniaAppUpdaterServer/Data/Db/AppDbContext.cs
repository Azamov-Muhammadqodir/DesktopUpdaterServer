using Microsoft.EntityFrameworkCore;

namespace AvaloniaAppUpdaterServer.Data.Db
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<AppFile> AppFiles { get; set; }
    }
}
