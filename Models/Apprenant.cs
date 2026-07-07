namespace PlateE_learning.Models
{
    public class Apprenant : Utilisateur
    {
        public ICollection<Cours> CoursSuivis { get; set; } = new List<Cours>();
        public ICollection<Certificat> Certificats { get; set; } = new List<Certificat>();
    }
}
