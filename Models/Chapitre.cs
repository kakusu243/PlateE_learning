namespace PlateE_learning.Models
{
    public class Chapitre
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Contenu { get; set; } = string.Empty;
        public int Ordre { get; set; }
    }
}
