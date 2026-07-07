namespace PlateE_learning.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } // Texte ou Vidéo
        public ICollection<Chapitre> Chapitres { get; set; } = new List<Chapitre>();
        public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
        public ICollection<Apprenant> Apprenants { get; set; } = new List<Apprenant>();
    }
}
