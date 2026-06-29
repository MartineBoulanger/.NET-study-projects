using Microsoft.EntityFrameworkCore;

namespace SterrenbeeldService.Repositories
{
    public class SterrenbeeldContext(DbContextOptions<SterrenbeeldContext> options):DbContext(options)
    {
        public DbSet<Sterrenbeeld> Sterrenbeelden { get; init; }
    }
}
