namespace PlateE_learning.Models
{
<<<<<<< HEAD
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
=======
    public class Chapitre
{
    public int Id { get; set; }
    public string Titre { get; set; } = string.Empty;

    // Contenu texte (pour les cours classiques)
    public string? ContenuTexte { get; set; }

    // URL ou chemin de la vidéo (pour les cours vidéo)
    public string? VideoUrl { get; set; }

    public int Ordre { get; set; }

    // 🔗 Clé étrangère et navigation
    public int CoursId { get; set; }
    public Cours? Cours { get; set; }
}

>>>>>>> 1d1b764cc5b3455f0cfe3aed61364bdb491f096f
}