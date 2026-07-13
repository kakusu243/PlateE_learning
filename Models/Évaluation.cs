namespace PlateE_learning.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty; // QCM, Sondage
        public string Questions { get; set; } = string.Empty;
        public int NoteMax { get; set; }
    }
}
