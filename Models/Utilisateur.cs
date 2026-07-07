namespace PlateE_learning.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string NomComplet { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Enseignant, Apprenant, Admin
        public DateTime DateInscription { get; set; }
    }
}
