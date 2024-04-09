using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using TimeCapsule.WebApi.Contracts.Requests;
using TimeCapsule.WebApi.Extensions.Responses;
using TimeCapsule.WebApi.Services;

namespace TimeCapsule.WebApi.Endpoints.TimeCapsuleEndpoints;

public class GetTimeCapsuleEndpoint(TimeCapsuleService capsuleService)
    : Endpoint<GetTimeCapsuleRequest, TimeCapsuleResponse>
{
    public override void Configure()
    {
        Get("/time-capsules/{id}");
        ResponseCache(60);
    }

    public override async Task HandleAsync(GetTimeCapsuleRequest request, CancellationToken ct)
    {
        var success = int.TryParse(request.Id, out var parsedId);
        if (!success)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var response = await capsuleService.GetTimeCapsule(parsedId);

        if (response == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(response, ct);
    }
}
