using System.ComponentModel.DataAnnotations;

namespace PlateE_learning.Models;

public class AppUser
{
    public int Id { get; set; }

    [Required]
    public string DisplayName { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    public string Role { get; set; } = Roles.Learner;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public IList<Course> Courses { get; set; } = new List<Course>();
    public IList<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public IList<Certificate> Certificates { get; set; } = new List<Certificate>();
}
