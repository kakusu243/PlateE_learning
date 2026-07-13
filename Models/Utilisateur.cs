namespace PlateE_learning.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string NomComplet { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // Enseignant, Apprenant, Admin
        public string PhotoUrl { get; set; } = "images/avatar-default.svg";
        public string MotDePasse { get; set; } = string.Empty;
        public DateTime DateInscription { get; set; }
    }
}
