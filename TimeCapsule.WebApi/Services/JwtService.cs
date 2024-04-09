using TimeCapsule.Data.Models;
using FastEndpoints.Security;

namespace TimeCapsule.WebApi.Services;

public class JwtService
{
    public string CreateTokenForUser(User user)
    {
        var jwtToken = JwtBearer.CreateToken(options =>
        {
            options.SigningKey = "A secret token signing key";
            options.ExpireAt = DateTime.UtcNow.AddDays(1);
            // options.User.Roles.Add("Manager", "Auditor");
            options.User.Claims.Add(("UserName", user.Username));
            options.User.Claims.Add(("Email", user.Email));
            options.User.Claims.Add(("UserId", user.Id.ToString()));
        });

        return jwtToken;
    }
}
