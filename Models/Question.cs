using System.ComponentModel.DataAnnotations;

namespace PlateE_learning.Models;

public class Question
{
    public int Id { get; set; }

    [Required]
    public string Text { get; set; } = string.Empty;

    public bool IsMultipleChoice { get; set; } = true;

    public int EvaluationId { get; set; }
    public Evaluation? Evaluation { get; set; }

    public IList<AnswerOption> Options { get; set; } = new List<AnswerOption>();
}
