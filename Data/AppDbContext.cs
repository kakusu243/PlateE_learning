using Microsoft.EntityFrameworkCore;
using PlateE_learning.Models;

namespace PlateE_learning.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Chapitre> Chapitres { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Certificat> Certificats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de l'héritage TPH (Table-per-Hierarchy) pour Utilisateur
            // EF Core créera une seule table "Utilisateurs" avec une colonne "Discriminator" automatique.
            modelBuilder.Entity<Utilisateur>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Utilisateur>("Utilisateur")
                .HasValue<Apprenant>("Apprenant")
                .HasValue<Enseignant>("Enseignant")
                .HasValue<Administrateur>("Administrateur");

            // Relation 1-to-Many : Cours -> Chapitres (Cascade Delete)
            modelBuilder.Entity<Cours>()
                .HasMany(c => c.Chapitres)
                .WithOne(ch => ch.Cours)         // Associe explicitement la navigation inverse
                .HasForeignKey(ch => ch.CoursId) // Indique la clé étrangère définie dans Chapitre
                .OnDelete(DeleteBehavior.Cascade);

            // Relation 1-to-Many : Cours -> Evaluations (Cascade Delete)
            modelBuilder.Entity<Cours>()
                .HasMany(c => c.Evaluations)
                .WithOne(e => e.Cours)           // Associe explicitement la navigation inverse
                .HasForeignKey(e => e.CoursId)   // Indique la clé étrangère définie dans Evaluation
                .OnDelete(DeleteBehavior.Cascade);

            // Relation 1-to-Many : Enseignant -> Cours (Set Null sur suppression de l'enseignant)
            modelBuilder.Entity<Cours>()
                .HasOne(c => c.Enseignant)
                .WithMany(e => e.CoursCrees)
                .HasForeignKey(c => c.EnseignantId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relation Many-to-Many : Apprenant <-> Cours
            modelBuilder.Entity<Apprenant>()
                .HasMany(a => a.CoursSuivis)
                .WithMany(c => c.Apprenants);

            // Relation 1-to-Many : Apprenant -> Certificats (Cascade Delete)
            // On s'assure qu'un certificat est bien lié à un apprenant en base de données.
            modelBuilder.Entity<Apprenant>()
                .HasMany(a => a.Certificats)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}