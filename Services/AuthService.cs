using Microsoft.EntityFrameworkCore;
using PlateE_learning.Data;
using PlateE_learning.Models;
using System.Security.Claims;

namespace PlateE_learning.Services;

public class AuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AppUser?> AuthenticateAsync(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user is null)
        {
            return null;
        }

        return PasswordHasher.VerifyHash(password, user.PasswordHash) ? user : null;
    }

    public async Task<(bool Succeeded, string ErrorMessage)> RegisterAsync(string displayName, string email, string password, string role)
    {
        if (await _context.Users.AnyAsync(u => u.Email == email))
        {
            return (false, "Un utilisateur existe déjà avec cette adresse e-mail.");
        }

        var user = new AppUser
        {
            DisplayName = displayName,
            Email = email,
            PasswordHash = PasswordHasher.CreateHash(password),
            Role = role,
            CreatedOn = DateTime.UtcNow,
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return (true, string.Empty);
    }

    public static ClaimsPrincipal CreatePrincipal(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.DisplayName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
        };

        var identity = new ClaimsIdentity(claims, "CustomAuth");
        return new ClaimsPrincipal(identity);
    }

    public async Task<AppUser?> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}
