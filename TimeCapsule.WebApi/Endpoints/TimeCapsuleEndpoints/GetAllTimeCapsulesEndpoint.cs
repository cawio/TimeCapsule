using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using TimeCapsule.WebApi.Services;

namespace TimeCapsule.WebApi;

[HttpGet("/time-capsules"), AllowAnonymous]
public class GetAllTimeCapsulesEndpoint(TimeCapsuleService capsuleService) : EndpointWithoutRequest<GetAllTimeCapsulesResponse>
{
    public override async Task HandleAsync(CancellationToken ct)
    {
        var response = await capsuleService.GetTimeCapsules();

        await SendOkAsync(response, ct);
    }
}