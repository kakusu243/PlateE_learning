using Microsoft.AspNetCore.Identity;

namespace PlateE_learning.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NomComplet { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = "images/avatar-default.svg";
        public DateTime DateInscription { get; set; } = DateTime.UtcNow;
        // Flag to indicate user must change temporary password on first login
        public bool MustChangePassword { get; set; } = false;
    }
}
