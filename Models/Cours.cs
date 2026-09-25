namespace PlateE_learning.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = "Texte"; // Texte ou Vidéo
        public string Statut { get; set; } = "Brouillon"; // Brouillon ou Publié
        public string MiniatureUrl { get; set; } = "images/course-default.svg";

        // 🔗 Relation vers l'enseignant créateur (typée Enseignant)
        public int? EnseignantId { get; set; }
        public Enseignant? Enseignant { get; set; }

        public ICollection<Chapitre> Chapitres { get; set; } = new List<Chapitre>();
        public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
        public ICollection<Certificat> Certificats { get; set; } = new List<Certificat>();
    }
}