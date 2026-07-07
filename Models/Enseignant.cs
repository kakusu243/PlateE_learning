namespace PlateE_learning.Models
{
    public class Enseignant : Utilisateur
    {
        public ICollection<Cours> CoursCrees { get; set; } = new List<Cours>();
    }
}
