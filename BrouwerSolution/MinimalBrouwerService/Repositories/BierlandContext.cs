using Microsoft.EntityFrameworkCore;
using MinimalBrouwerService.Models;

namespace MinimalBrouwerService.Repositories
{
    public class BierlandContext(DbContextOptions<BierlandContext> options):DbContext(options)
    {
        public required DbSet<Brouwer> Brouwers { get; set; }
        //public required DbSet<Woonplaats> Woonplaatsen { get; init; }
        //public required DbSet<Filiaal> Filialen { get; init; }
    }
}
