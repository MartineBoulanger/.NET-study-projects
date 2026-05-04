using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Model.Entities
{
    public class EFOpleidingenContext : DbContext
    {
        public static IConfigurationRoot? configuration;

        // entity collections
        public DbSet<Campus> Campussen { get; set; }
        public DbSet<Docent> Docenten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connectionstring hardcoded
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFOpleidingen;Trusted_Connection=true;encrypt=false", options => options.MaxBatchSize(150));
            // connection string ophalen uit the configuratie bestand
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName).AddJsonFile("appsettings.json", false).Build();
            var connectionString = configuration.GetConnectionString("EFOpleidingen");
            if (connectionString != null) optionsBuilder.UseSqlServer(connectionString, options => options.MaxBatchSize(150));
        }
    }
}
