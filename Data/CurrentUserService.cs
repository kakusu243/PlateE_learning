using PlateE_learning.Models;

namespace PlateE_learning.Data
{
    public class CurrentUserService
    {
        public Utilisateur? CurrentUser { get; private set; }

        public bool IsAuthenticated => CurrentUser != null;
        public string? Role => CurrentUser?.Role;

        public event Action? OnChange;

        public void SetUser(Utilisateur user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        public void Logout()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
