using Microsoft.EntityFrameworkCore;
using PlateE_learning.Data;
using PlateE_learning.Components; // Assure-toi que cela pointe vers le dossier contenant ton App.razor

var builder = WebApplication.CreateBuilder(args);

// 1. 🔗 Connexion MySQL (via Pomelo) avec DbContextFactory (Indispensable pour Blazor Server)
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36)) // Adapte à ta version de MySQL locale
    )
);

// 2. ⚙️ Services Blazor modernes (.NET 8)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 3. 🛡️ Service utilisateur (scoped pour isoler chaque session de navigateur)
builder.Services.AddScoped<CurrentUserService>();

// 4. 🛡️ Service d'anti-falsification (obligatoire pour les formulaires en .NET 8)
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

app.MapStaticAssets(); // Gère les assets modernes de .NET 8

// 🌟 Configurer l'application pour utiliser ton App.razor avec le mode interactif
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();