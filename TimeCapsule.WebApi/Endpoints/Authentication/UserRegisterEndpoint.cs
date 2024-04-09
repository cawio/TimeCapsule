using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using TimeCapsule.WebApi.Contracts.Responses;
using TimeCapsule.WebApi.Services;

namespace TimeCapsule.WebApi.Endpoints.Authentication;

[HttpPost("/auth/register"), AllowAnonymous]
public class UserRegisterEndpoint(AuthService auth) : Endpoint<RegisterRequest, LoginResponse>
{
    public override async Task HandleAsync(RegisterRequest request, CancellationToken ct)
    {
        var user = await auth.RegisterUser(request.Email, request.Password);
        var (_, token) = await auth.CredentialsAreValid(request.Email, request.Password);

        if (user == null || string.IsNullOrWhiteSpace(token))
        {
            await SendUnauthorizedAsync(ct);
        }

        var response = new LoginResponse
        {
            Username = request.Email,
            Token = token!,
        };

        await SendOkAsync(response, ct);
    }
}
