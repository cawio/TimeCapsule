using System.Security.Cryptography;
using System.Text;

namespace TimeCapsule.WebApi.Services;

public class PasswordService
{
    public byte[] HashPassword(string password, out byte[] salt)
    {
        using var hmac = new HMACSHA512();
        salt = hmac.Key;

        return hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
    {
        using var hmac = new HMACSHA512(storedSalt);
        byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return computedHash.SequenceEqual(storedHash);
    }
}
