namespace PlateE_learning.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty; // QCM, Sondage
        public string Questions { get; set; } = string.Empty; // Stockage JSON ou texte
        public int NoteMax { get; set; }

        // 🔗 Clé étrangère et propriété de navigation vers le Cours
        public int CoursId { get; set; }
        public Cours? Cours { get; set; }
    }
}
