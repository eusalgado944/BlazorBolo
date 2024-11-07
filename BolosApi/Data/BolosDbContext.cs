using BolosModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace BolosApi.Data
{


    public class BolosDbContext : DbContext
    {
        public BolosDbContext(DbContextOptions<BolosDbContext> options) : base(options) { }

        public DbSet<Bolo> Bolos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bolo>()
                .Property(b => b.Valor)
                .HasColumnType("decimal(18,2)");
        }
    }
}