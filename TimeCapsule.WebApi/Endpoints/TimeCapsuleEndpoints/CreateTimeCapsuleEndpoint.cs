using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using TimeCapsule.WebApi.Contracts.Requests;
using TimeCapsule.WebApi.Contracts.Responses;
using TimeCapsule.WebApi.Services;

namespace TimeCapsule.WebApi.Endpoints.TimeCapsuleEndpoints;

[HttpPost("/time-capsules")]
public class CreateTimeCapsuleEndpoint(TimeCapsuleService capsuleService) : Endpoint<CreateTimeCapsuleRequest, CreateTimeCapsuleResponse>
{
    public override async Task HandleAsync(CreateTimeCapsuleRequest request, CancellationToken ct)
    {
        var response = await capsuleService.CreateTimeCapsule(request);
        await SendOkAsync(response, ct);
    }
}
