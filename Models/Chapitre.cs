namespace PlateE_learning.Models
{
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

}