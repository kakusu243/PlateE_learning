using Microsoft.EntityFrameworkCore;
using PlateE_learning.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔗 Connexion MySQL (via Pomelo)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36)) // adapte à ta version MySQL
    )
);

// ⚙️ Services Blazor
builder.Services.AddRazorPages(options =>
{
    // Change la racine des Razor Pages vers Components/Pages
    options.RootDirectory = "/Components/Pages";
});
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<CurrentUserService>();

var app = builder.Build();

SeedData.EnsureSeedData(app);

// 🔧 Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
