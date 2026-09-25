namespace PlateE_learning.Models
{
    public class Certificat
    {
        public int Id { get; set; }
        public string NumeroUnique { get; set; } = string.Empty;
        public DateTime DateEmission { get; set; } = DateTime.UtcNow;
        public string NomApprenant { get; set; } = string.Empty;
        public string TitreCours { get; set; } = string.Empty;
        public string Signataire { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // 🔗 Relation vers l'apprenant (typée Apprenant)
        public int ApprenantId { get; set; }
        public Apprenant? Apprenant { get; set; }

        // 🔗 Relation vers le cours
        public int CoursId { get; set; }
        public Cours? Cours { get; set; }
    }
}