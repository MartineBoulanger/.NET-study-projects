using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Model.Entities
{
    public class EFTakenContext : DbContext
    {
        public static IConfigurationRoot configuration = null!;

        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Rekening> Rekeningen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var parent = Directory.GetParent(AppContext.BaseDirectory)?.FullName;
            configuration = new ConfigurationBuilder().SetBasePath(parent ?? null!).AddJsonFile("appsettings.json", false).Build();
            var connectionString = configuration.GetConnectionString("EFBank");
            if (connectionString != null) optionsBuilder.UseSqlServer(connectionString, options => options.MaxBatchSize(150));
        }
    }
}
