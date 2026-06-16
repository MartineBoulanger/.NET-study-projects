using Microsoft.EntityFrameworkCore;

namespace SchuttersData.Models;

public partial class SchuttersDbContext:DbContext
{
    public SchuttersDbContext() { }

    public SchuttersDbContext(DbContextOptions<SchuttersDbContext> options)
        : base(options) { }

    public virtual DbSet<Club> Clubs { get; set; }
    public virtual DbSet<Lid> Leden { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lid>()
            .HasOne(l => l.Club)
            .WithMany(c => c.Leden)
            .HasForeignKey(l => l.ClubId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
