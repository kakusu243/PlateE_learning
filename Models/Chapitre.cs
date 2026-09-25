namespace PlateE_learning.Models
{
    public abstract class Chapitre
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public int Ordre { get; set; }

        public int CoursId { get; set; }
        public Cours? Cours { get; set; }

        // 🔗 Navigation vers l'évaluation associée
        public Evaluation? Evaluation { get; set; }
    }

    public class ChapitreTexte : Chapitre
    {
        public string ContenuHtml { get; set; } = string.Empty;
    }

    public class ChapitreVideo : Chapitre
    {
        public string CheminFichierVideo { get; set; } = string.Empty;
        public int DureeEnSecondes { get; set; } = 0;
    }
}