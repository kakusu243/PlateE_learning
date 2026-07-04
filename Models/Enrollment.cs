using System.ComponentModel.DataAnnotations;

namespace PlateE_learning.Models;

public class Enrollment
{
    public int Id { get; set; }

    public int CourseId { get; set; }
    public Course? Course { get; set; }

    public int UserId { get; set; }
    public AppUser? User { get; set; }

    public DateTime EnrolledOn { get; set; } = DateTime.UtcNow;
    public bool IsComplete { get; set; }
    public bool CertificateIssued { get; set; }
}
