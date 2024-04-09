using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using TimeCapsule.WebApi.Extensions.Responses;
using TimeCapsule.WebApi.Services;

namespace TimeCapsule.WebApi;

[HttpPut("/time-capsules"), AllowAnonymous]
public class UpdateTimeCapsuleEndpoint(TimeCapsuleService capsuleService) : Endpoint<UpdateTimeCapsuleRequest, TimeCapsuleResponse>
{
    public override async Task HandleAsync(UpdateTimeCapsuleRequest req, CancellationToken ct)
    {
        var response = await capsuleService.UpdateTimeCapsule(req);

        if (response == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(response, ct);
    }
}