using Microsoft.EntityFrameworkCore;
using PlateE_learning.Data;
using PlateE_learning.Components; // Assure-toi que cela pointe vers le dossier contenant ton App.razor

var builder = WebApplication.CreateBuilder(args);

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