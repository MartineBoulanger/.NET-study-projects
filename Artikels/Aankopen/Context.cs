using Aankopen.Models;
using Microsoft.EntityFrameworkCore;

namespace Aankopen
{
    public class Context(DbContextOptions<Context> options):DbContext(options)
    {
        public required DbSet<Aankoop> Aankopen { init; get; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Aankoop>().Property(aankoop => aankoop.Prijs).HasColumnType("decimal(10,2)");
        }
    }
}
