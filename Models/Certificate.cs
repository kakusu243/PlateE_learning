using System.ComponentModel.DataAnnotations;

namespace PlateE_learning.Models;

public class Certificate
{
    public int Id { get; set; }

    [Required]
    public string RecipientName { get; set; } = string.Empty;

    [Required]
    public string CourseTitle { get; set; } = string.Empty;

    public DateTime IssuedOn { get; set; } = DateTime.UtcNow;
    public string? TemplateData { get; set; }
    public string PdfPath { get; set; } = string.Empty;

    public int UserId { get; set; }
    public AppUser? User { get; set; }
}
