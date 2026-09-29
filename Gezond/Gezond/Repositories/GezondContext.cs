using Gezond.Models;
using Microsoft.EntityFrameworkCore;

namespace Gezond.Repositories
{
    public class GezondContext(DbContextOptions<GezondContext> options): DbContext(options)
    {
        public required DbSet<Groente> Groenten { get; set; }
    }
}
