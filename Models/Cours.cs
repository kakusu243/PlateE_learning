namespace PlateE_learning.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Texte ou Vidéo
        public string MiniatureUrl { get; set; } = "images/course-default.svg";
        public int? EnseignantId { get; set; }
        public Enseignant? Enseignant { get; set; }
        public ICollection<Chapitre> Chapitres { get; set; } = new List<Chapitre>();
        public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
        public ICollection<Apprenant> Apprenants { get; set; } = new List<Apprenant>();
    }
}
