using System.Security.Cryptography;
using System.Text;

namespace PlateE_learning.Services;

public static class PasswordHasher
{
    private const int Iterations = 100_000;
    private const int SaltSize = 16;
    private const int HashSize = 32;

    public static string CreateHash(string input)
    {
        using var rng = RandomNumberGenerator.Create();
        var salt = new byte[SaltSize];
        rng.GetBytes(salt);

        using var pbkdf2 = new Rfc2898DeriveBytes(input, salt, Iterations, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(HashSize);

        var result = new byte[SaltSize + HashSize];
        Buffer.BlockCopy(salt, 0, result, 0, SaltSize);
        Buffer.BlockCopy(hash, 0, result, SaltSize, HashSize);

        return Convert.ToBase64String(result);
    }

    public static bool VerifyHash(string input, string hashString)
    {
        var decoded = Convert.FromBase64String(hashString);
        var salt = new byte[SaltSize];
        Buffer.BlockCopy(decoded, 0, salt, 0, SaltSize);

        using var pbkdf2 = new Rfc2898DeriveBytes(input, salt, Iterations, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(HashSize);

        for (var i = 0; i < HashSize; i++)
        {
            if (decoded[SaltSize + i] != hash[i])
            {
                return false;
            }
        }

        return true;
    }
}
