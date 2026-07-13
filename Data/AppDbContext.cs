using Microsoft.EntityFrameworkCore;
using PlateE_learning.Models;

namespace PlateE_learning.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Chapitre> Chapitres { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Certificat> Certificats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relations
            modelBuilder.Entity<Cours>()
                .HasMany(c => c.Chapitres)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cours>()
                .HasMany(c => c.Evaluations)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cours>()
                .HasOne(c => c.Enseignant)
                .WithMany(e => e.CoursCrees)
                .HasForeignKey(c => c.EnseignantId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Apprenant>()
                .HasMany(a => a.CoursSuivis)
                .WithMany(c => c.Apprenants);

            modelBuilder.Entity<Apprenant>()
                .HasMany(a => a.Certificats)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
