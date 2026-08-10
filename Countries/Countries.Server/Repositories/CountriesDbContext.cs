using Countries.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Countries.Server.Repositories
{
    public class CountriesDbContext(DbContextOptions<CountriesDbContext> options):DbContext(options)
    {
        public required DbSet<Country> Countries { get; set; }
        public required DbSet<Language> Languages { get; set; }
        public required DbSet<Flag> Flags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flag>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Id)
                .ValueGeneratedNever();

            });

            modelBuilder.Entity<Country>()
            .HasOne(c => c.Flag)
            .WithOne(f => f.Country)
            .HasForeignKey<Flag>(f => f.Id)
            .IsRequired();

            Language nederlands = new() { Id = 1, Name = "Nederlands" };
            Language frans = new() { Id = 2, Name = "Frans" };
            Language engels = new() { Id = 3, Name = "Engels" };
            Language duits = new() { Id = 4, Name = "Duits" };

            modelBuilder.Entity<Language>().HasData(
                [nederlands, frans, engels, duits]
            );

            modelBuilder.Entity<Country>().HasData(
                [
                    new Country() { Id=11, Name="België", Capital="Brussel", Population=11409},
                    new Country() { Id=12, Name="Nederland", Capital="Amsterdam", Population=17017},
                    new Country() { Id=13, Name="Verenigd Koninkrijk", Capital="Londen", Population=65014},
                    new Country() { Id=14, Name="Ierland", Capital="Dublin", Population=4952},
                    new Country() { Id=15, Name="Frankrijk", Capital="Parijs", Population=66836},
                    new Country() { Id=16, Name="Spanje", Capital="Madrid", Population=48563},
                    new Country() { Id=17, Name="Portugal", Capital="Lissabon", Population=10834},
                    new Country() { Id=18, Name="Italië", Capital="Rome", Population=62008},
                    new Country() { Id=19, Name="Zwitserland", Capital="Bern", Population=8287},
                    new Country(){Id=20,Name="Duitsland",Capital="Berlijn",Population=80723},
                ]
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
