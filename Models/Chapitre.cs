namespace PlateE_learning.Models
{
    public class Chapitre
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Contenu { get; set; } = string.Empty; // Gardera le type TEXT ou LONGTEXT
        public int Ordre { get; set; }

        // 🔗 Clé étrangère et propriété de navigation vers le Cours
        public int CoursId { get; set; }
        public Cours? Cours { get; set; }
    }
}