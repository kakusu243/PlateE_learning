using Microsoft.EntityFrameworkCore;
using PlateE_learning.Models;

namespace PlateE_learning.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Chapter> Chapters => Set<Chapter>();
    public DbSet<Evaluation> Evaluations => Set<Evaluation>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<AnswerOption> AnswerOptions => Set<AnswerOption>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Certificate> Certificates => Set<Certificate>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.Courses)
            .WithOne(c => c.CreatedBy)
            .HasForeignKey(c => c.CreatedById)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Chapters)
            .WithOne(ch => ch.Course)
            .HasForeignKey(ch => ch.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Evaluations)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Evaluation>()
            .HasMany(e => e.Questions)
            .WithOne(q => q.Evaluation)
            .HasForeignKey(q => q.EvaluationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Question>()
            .HasMany(q => q.Options)
            .WithOne(o => o.Question)
            .HasForeignKey(o => o.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.Enrollments)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Enrollments)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.Certificates)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
