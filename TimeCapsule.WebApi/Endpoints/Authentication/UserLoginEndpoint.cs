using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using TimeCapsule.WebApi.Contracts.Responses;
using TimeCapsule.WebApi.Services;

namespace TimeCapsule.WebApi.Endpoints.Authentication;

[HttpGet("/auth/login"), AllowAnonymous]
public class UserLoginEndpoint(AuthService auth) : Endpoint<LoginRequest, LoginResponse>
{
    public override async Task HandleAsync(LoginRequest request, CancellationToken ct)
    {
        var (success, token) = await auth.CredentialsAreValid(request.Email, request.Password);
        if (success && !string.IsNullOrWhiteSpace(token))
        {
            var response = new LoginResponse
            {
                Username = request.Email,
                Token = token,
            };

            await SendOkAsync(response, ct);
        }

        await SendUnauthorizedAsync(ct);
    }
}
