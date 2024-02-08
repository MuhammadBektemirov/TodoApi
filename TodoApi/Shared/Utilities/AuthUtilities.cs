using System.Security.Cryptography;
using System.Text;

namespace TodoApi.Shared.Utilities;

public static class AuthUtilities
{
    public static string SHA256Converter(string email, string password)
    {
        using var sha256 = SHA256.Create();
        var hash = new StringBuilder();
        var hashArray = sha256.ComputeHash(Encoding.UTF8.GetBytes($"{email}:{password}"));
        hashArray.ToList().ForEach(b => hash.Append(b.ToString("x")));
            
        return hash.ToString();
    }
}