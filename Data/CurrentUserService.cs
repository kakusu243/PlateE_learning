using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PlateE_learning.Models;

namespace PlateE_learning.Data
{
    public class CurrentUserService
    {
        // Identity-backed current user
        public ApplicationUser? CurrentUser { get; private set; }

        // Lightweight compatibility wrapper for code that still consumes Utilisateur
        public Utilisateur? LegacyUser { get; private set; }

        public bool IsAuthenticated => CurrentUser != null;
        public string? Role => LegacyUser?.Role ?? CurrentUser?.UserName;

        public event Action? OnChange;

        public void SetUser(ApplicationUser user)
        {
            CurrentUser = user;
            LegacyUser = MapToLegacy(user);
            NotifyStateChanged();
        }

        public void Logout()
        {
            CurrentUser = null;
            LegacyUser = null;
            NotifyStateChanged();
        }

        public async Task InitializeAsync(ClaimsPrincipal principal, UserManager<ApplicationUser> userManager)
        {
            if (principal?.Identity?.IsAuthenticated != true)
            {
                Logout();
                return;
            }

            var user = await userManager.GetUserAsync(principal);
            if (user != null)
            {
                SetUser(user);
            }
            else
            {
                Logout();
            }
        }

        private Utilisateur MapToLegacy(ApplicationUser u)
        {
            return new Utilisateur
            {
                Id = 0, // Unknown mapping; keep 0 to indicate migrated user
                NomComplet = u.NomComplet,
                Email = u.Email ?? string.Empty,
                Role = string.Empty, // role is available via claims or via UserManager when needed
                PhotoUrl = u.PhotoUrl ?? "images/avatar-default.svg",
                DateInscription = u.DateInscription
            };
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
