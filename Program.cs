using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using PlateE_learning.Components;
using PlateE_learning.Data;
using PlateE_learning.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AppAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<AppAuthenticationStateProvider>());
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CertificateService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
await SeedData.EnsureSeedDataAsync(dbContext);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
