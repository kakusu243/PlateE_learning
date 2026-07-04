using System.ComponentModel.DataAnnotations;

namespace PlateE_learning.Models;

public class Chapter
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Order { get; set; }

    public int CourseId { get; set; }
    public Course? Course { get; set; }
}
