using Microsoft.EntityFrameworkCore;
using PlateE_learning.Models;

namespace PlateE_learning.Data
{
    public static class SeedData
    {
        public static void EnsureSeedData(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            db.Database.Migrate();

            if (!db.Utilisateurs.Any())
            {
                var admin = new Administrateur
                {
                    NomComplet = "Admin Test",
                    Email = "admin@example.com",
                    Role = "Admin",
                    MotDePasse = "password",
                    DateInscription = DateTime.UtcNow
                };

                var teacher = new Enseignant
                {
                    NomComplet = "Luca Enseignant",
                    Email = "prof@example.com",
                    Role = "Enseignant",
                    MotDePasse = "password",
                    DateInscription = DateTime.UtcNow,
                    PhotoUrl = "images/avatar-default.svg"
                };

                var student = new Apprenant
                {
                    NomComplet = "Inès Apprenant",
                    Email = "eleve@example.com",
                    Role = "Apprenant",
                    MotDePasse = "password",
                    DateInscription = DateTime.UtcNow
                };

                db.Utilisateurs.AddRange(admin, teacher, student);
                db.SaveChanges();
            }

            if (!db.Cours.Any())
            {
                var teacher = db.Utilisateurs.OfType<Enseignant>().FirstOrDefault();

                db.Cours.AddRange(
                    new Cours
                    {
                        Titre = "Développement Web Moderne",
                        Description = "Apprenez HTML, CSS et JavaScript avec des projets réels.",
                        Type = "Vidéo",
                        MiniatureUrl = "images/course-default.svg",
                        Enseignant = teacher
                    },
                    new Cours
                    {
                        Titre = "Marketing Digital",
                        Description = "Maîtrisez les stratégies de marketing, SEO et réseaux sociaux.",
                        Type = "Texte",
                        MiniatureUrl = "images/course-default.svg",
                        Enseignant = teacher
                    },
                    new Cours
                    {
                        Titre = "Gestion de Projet Agile",
                        Description = "Organisez vos équipes et livrez des projets avec succès.",
                        Type = "Vidéo",
                        MiniatureUrl = "images/course-default.svg",
                        Enseignant = teacher
                    },
                    new Cours
                    {
                        Titre = "Design UX/UI",
                        Description = "Créez des interfaces intuitives et des expériences utilisateur fluides.",
                        Type = "Texte",
                        MiniatureUrl = "images/course-default.svg",
                        Enseignant = teacher
                    },
                    new Cours
                    {
                        Titre = "Python pour les Débutants",
                        Description = "Apprenez les bases du langage Python étape par étape.",
                        Type = "Vidéo",
                        MiniatureUrl = "images/course-default.svg",
                        Enseignant = teacher
                    }
                );
            }

            db.SaveChanges();
        }
    }
}
