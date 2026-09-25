namespace PlateE_learning.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string Titre { get; set; } = "Évaluation du chapitre";
        public string Type { get; set; } = "QCM"; // QCM, Vrai/Faux, Sondage
        public int NoteMax { get; set; } = 20;

        // 🔗 Relation 1-à-N : Une évaluation contient plusieurs questions
        public List<Question> Questions { get; set; } = new();

        // 🔗 Clé étrangère et relation vers Chapitre
        public int ChapitreId { get; set; }
        public Chapitre? Chapitre { get; set; }
    }
}