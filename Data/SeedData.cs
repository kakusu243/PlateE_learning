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
            var roleManager = scope.ServiceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<Microsoft.AspNetCore.Identity.IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.UserManager<PlateE_learning.Models.ApplicationUser>>();

            db.Database.Migrate();

            // Ensure roles exist
            var roles = new[] { "Admin", "Enseignant", "Apprenant" };
            foreach (var role in roles)
            {
                if (!roleManager.RoleExistsAsync(role).GetAwaiter().GetResult())
                {
                    roleManager.CreateAsync(new Microsoft.AspNetCore.Identity.IdentityRole(role)).GetAwaiter().GetResult();
                }
            }

            // Ensure an admin Identity user exists
            var adminEmail = "admin@example.com";
            if (userManager.FindByEmailAsync(adminEmail).GetAwaiter().GetResult() == null)
            {
                var adminUser = new PlateE_learning.Models.ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    NomComplet = "Admin Identity",
                    DateInscription = DateTime.UtcNow
                };
                var result = userManager.CreateAsync(adminUser, "Admin@12345!").GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
                }
            }

            // Migrate existing Utilisateurs (if any) into Identity users
            var existingUsers = db.Utilisateurs.AsNoTracking().ToList();
            foreach (var legacy in existingUsers)
            {
                if (string.IsNullOrWhiteSpace(legacy.Email))
                    continue;

                var existingIdentity = userManager.FindByEmailAsync(legacy.Email).GetAwaiter().GetResult();
                if (existingIdentity != null)
                    continue; // already migrated or user exists

                var tempPassword = "Temp@" + Guid.NewGuid().ToString("N").Substring(0, 12) + "aA1!";

                var newUser = new PlateE_learning.Models.ApplicationUser
                {
                    UserName = legacy.Email,
                    Email = legacy.Email,
                    NomComplet = legacy.NomComplet,
                    PhotoUrl = string.IsNullOrEmpty(legacy.PhotoUrl) ? "images/avatar-default.svg" : legacy.PhotoUrl,
                    DateInscription = legacy.DateInscription,
                    MustChangePassword = true
                };

                var createResult = userManager.CreateAsync(newUser, tempPassword).GetAwaiter().GetResult();
                if (createResult.Succeeded)
                {
                    var role = !string.IsNullOrWhiteSpace(legacy.Role) ? legacy.Role : "Apprenant";
                    if (!roleManager.RoleExistsAsync(role).GetAwaiter().GetResult())
                        roleManager.CreateAsync(new Microsoft.AspNetCore.Identity.IdentityRole(role)).GetAwaiter().GetResult();

                    userManager.AddToRoleAsync(newUser, role).GetAwaiter().GetResult();

                    // add a claim to force password reset on first login
                    userManager.AddClaimAsync(newUser, new System.Security.Claims.Claim("must_change_password", "true")).GetAwaiter().GetResult();
                }
                else
                {
                    // Could log errors here; for now we ignore and continue
                }
            }

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
