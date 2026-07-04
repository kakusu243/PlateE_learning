using System.ComponentModel.DataAnnotations;

namespace PlateE_learning.Models;

public class Evaluation
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public bool IsSurvey { get; set; }

    public int CourseId { get; set; }
    public Course? Course { get; set; }

    public IList<Question> Questions { get; set; } = new List<Question>();
}
