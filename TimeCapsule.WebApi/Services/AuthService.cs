using Microsoft.AspNetCore.Identity;
using TimeCapsule.WebApi.Repositories;

namespace TimeCapsule.WebApi.Services;

public class AuthService(UserRepository users, PasswordService passwordService, JwtService jwt)
{
    public async Task<(bool, string?)> CredentialsAreValid(string email, string password)
    {
        var user = await users.GetUserByEmail(email);

        if (user == null)
        {
            return (false, null);
        }

        var isValid = passwordService.VerifyPassword(password, user.PasswordHash, user.Salt);
        if (isValid)
        {
            var token = jwt.CreateTokenForUser(user);
            return (true, token);
        }

        return (false, null);
    }

    public async Task<Data.Models.User> RegisterUser(string email, string password)
    {
        var passwordHash = passwordService.HashPassword(password, out var salt);

        var user = new Data.Models.User
        {
            Email = email,
            PasswordHash = passwordHash,
            Salt = salt
        };

        return await users.CreateUser(user);
    }
}
