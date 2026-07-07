namespace PlateE_learning.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string Type { get; set; } // QCM, Sondage
        public string Questions { get; set; }
        public int NoteMax { get; set; }
    }
}
