using Microsoft.EntityFrameworkCore;
using PlateE_learning.Models;
using PlateE_learning.Services;

namespace PlateE_learning.Data;

public static class SeedData
{
    public static async Task EnsureSeedDataAsync(AppDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (await context.Users.AnyAsync())
        {
            return;
        }

        var admin = new AppUser
        {
            DisplayName = "Administrator",
            Email = "admin@platee.local",
            PasswordHash = PasswordHasher.CreateHash("Admin123!"),
            Role = Roles.Admin
        };

        var teacher = new AppUser
        {
            DisplayName = "Enseignant Demo",
            Email = "teacher@platee.local",
            PasswordHash = PasswordHasher.CreateHash("Teacher123!"),
            Role = Roles.Teacher
        };

        var learner = new AppUser
        {
            DisplayName = "Apprenant Demo",
            Email = "learner@platee.local",
            PasswordHash = PasswordHasher.CreateHash("Learner123!"),
            Role = Roles.Learner
        };

        context.Users.AddRange(admin, teacher, learner);
        await context.SaveChangesAsync();

        var sampleCourse = new Course
        {
            Title = "Découverte de la plateforme PlateE",
            Description = "Apprenez à utiliser la plateforme, suivre un cours et générer un certificat.",
            CreatedById = teacher.Id,
            IsPublished = true,
            CreatedOn = DateTime.UtcNow,
        };

        context.Courses.Add(sampleCourse);
        await context.SaveChangesAsync();

        context.Chapters.AddRange(
            new Chapter { CourseId = sampleCourse.Id, Order = 1, Title = "Bienvenue", Summary = "Vue d'ensemble du parcours" , Content = "Présentation du cours et des fonctionnalités."},
            new Chapter { CourseId = sampleCourse.Id, Order = 2, Title = "Modules", Summary = "Organisation du contenu" , Content = "Chaque chapitre représente un bloc d'apprentissage."},
            new Chapter { CourseId = sampleCourse.Id, Order = 3, Title = "Évaluations", Summary = "QCM et sondages" , Content = "Répondez aux questions pour valider votre progression."}
        );

        await context.SaveChangesAsync();
    }
}
