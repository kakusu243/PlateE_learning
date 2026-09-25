using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PlateE_learning.Models;

namespace PlateE_learning.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Apprenant> Apprenants { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ResultatEvaluation> ResultatEvaluations { get; set; }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<MessageForum> MessagesForum { get; set; }

        // Entités Chapitres
        public DbSet<Chapitre> Chapitres { get; set; }
        public DbSet<ChapitreTexte> ChapitresTexte { get; set; }
        public DbSet<ChapitreVideo> ChapitresVideo { get; set; }

        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Certificat> Certificats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
<<<<<<< HEAD
            base.OnModelCreating(modelBuilder);

            // 1. Configuration de l'héritage TPH pour Utilisateur
=======
            // Call base to configure Identity schema first
            base.OnModelCreating(modelBuilder);

            // Configuration de l'héritage TPH (Table-per-Hierarchy) pour Utilisateur
            // EF Core créera une seule table "Utilisateurs" avec une colonne "Discriminator" automatique.
>>>>>>> 1d1b764cc5b3455f0cfe3aed61364bdb491f096f
            modelBuilder.Entity<Utilisateur>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Utilisateur>("Utilisateur")
                .HasValue<Apprenant>("Apprenant")
                .HasValue<Enseignant>("Enseignant")
                .HasValue<Administrateur>("Administrateur");

            // 1b. Configuration de l'héritage TPH pour Chapitre
            modelBuilder.Entity<Chapitre>()
                .HasDiscriminator<string>("TypeChapitre")
                .HasValue<ChapitreTexte>("Texte")
                .HasValue<ChapitreVideo>("Video");

            // 2. Relation Cours -> Chapitres (Cascade Delete)
            modelBuilder.Entity<Cours>()
                .HasMany(c => c.Chapitres)
                .WithOne(ch => ch.Cours)
                .HasForeignKey(ch => ch.CoursId)
                .OnDelete(DeleteBehavior.Cascade);

            // 3. Relation Chapitre 1-à-1 avec Evaluation (Cascade Delete)
            modelBuilder.Entity<Chapitre>()
                .HasOne(ch => ch.Evaluation)
                .WithOne(e => e.Chapitre)
                .HasForeignKey<Evaluation>(e => e.ChapitreId)
                .OnDelete(DeleteBehavior.Cascade);

            // 4. Relation Enseignant -> Cours (SetNull si suppression)
            modelBuilder.Entity<Cours>()
                .HasOne(c => c.Enseignant)
                .WithMany(e => e.CoursCrees)
                .HasForeignKey(c => c.EnseignantId)
                .OnDelete(DeleteBehavior.SetNull);

            // 5. Configuration de l'entité de jonction Inscription (Apprenant <-> Cours)
            modelBuilder.Entity<Inscription>()
                .HasOne(i => i.Apprenant)
                .WithMany()
                .HasForeignKey(i => i.ApprenantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Inscription>()
                .HasOne(i => i.Cours)
                .WithMany(c => c.Inscriptions)
                .HasForeignKey(i => i.CoursId)
                .OnDelete(DeleteBehavior.Cascade);

            // 6. Configuration des relations du Certificat
            modelBuilder.Entity<Certificat>()
                .HasOne(c => c.Apprenant)
                .WithMany(a => a.Certificats)
                .HasForeignKey(c => c.ApprenantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Certificat>()
                .HasOne(c => c.Cours)
                .WithMany(c => c.Certificats)
                .HasForeignKey(c => c.CoursId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}