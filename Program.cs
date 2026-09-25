using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using PlateE_learning.Data;
using PlateE_learning.Models;
using PlateE_learning.Components; // Assure-toi que cela pointe vers le dossier contenant ton App.razor

var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
// 1. 🔗 Connexion MariaDB/MySQL (via Pomelo) ajustée sur MariaDB 10.4.32
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MariaDbServerVersion(new Version(10, 4, 32))
    ));

// Augmenter la limite pour les formulaires multipart / upload de fichiers grands (ex: 500 MB)
builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 500 * 1024 * 1024; // 500 MB
});
=======
// 1. 🔗 Connexion MySQL (via Pomelo) avec DbContextFactory (Indispensable pour Blazor Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    ));

>>>>>>> 1d1b764cc5b3455f0cfe3aed61364bdb491f096f

// 2. ⚙️ Services Blazor modernes (.NET 8)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 3. 🛡️ Service utilisateur (scoped pour isoler chaque session de navigateur)
builder.Services.AddScoped<CurrentUserService>();

// 6. 🧰 Identity: utilisateurs et rôles persistés via EF Core
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Configure secure cookies for Identity
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/access-denied";
    options.ExpireTimeSpan = TimeSpan.FromDays(14);
    options.SlidingExpiration = true;
});

// 4. Service de feedback visuel Toast/Snackbar pour le workflow de création de cours
builder.Services.AddScoped<ToastService>();

// 5. 🛡️ Service d'anti-falsification (obligatoire pour les formulaires en .NET 8)
builder.Services.AddAntiforgery();

var app = builder.Build();

// Initialisation de ta base de données (SeedData)
SeedData.EnsureSeedData(app);

// 🔧 Pipeline de requêtes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery(); // Doit être placé avant le routage des composants
<<<<<<< HEAD
=======

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

>>>>>>> 1d1b764cc5b3455f0cfe3aed61364bdb491f096f
app.MapStaticAssets(); // Gère les assets modernes de .NET 8

// 🌟 Configurer l'application pour utiliser ton App.razor avec le mode interactif
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();