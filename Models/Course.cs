using System.ComponentModel.DataAnnotations;

namespace PlateE_learning.Models;

public class Course
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsPublished { get; set; } = true;

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public int CreatedById { get; set; }
    public AppUser? CreatedBy { get; set; }

    public IList<Chapter> Chapters { get; set; } = new List<Chapter>();
    public IList<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    public IList<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
