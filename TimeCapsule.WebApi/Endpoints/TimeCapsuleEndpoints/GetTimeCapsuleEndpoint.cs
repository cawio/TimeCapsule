using FastEndpoints;
using TimeCapsule.WebApi.Contracts.Requests;
using TimeCapsule.WebApi.Extensions.Responses;
using TimeCapsule.WebApi.Services;

namespace TimeCapsule.WebApi.Endpoints.TimeCapsuleEndpoints;

[HttpGet("/time-capsules/{id:string}")]
public class GetTimeCapsuleEndpoint(TimeCapsuleService capsuleService) : Endpoint<GetTimeCapsuleRequest, TimeCapsuleResponse>
{
    public override async Task HandleAsync(GetTimeCapsuleRequest request, CancellationToken ct)
    {
        var response = await capsuleService.GetTimeCapsule(request.Id);
        await SendOkAsync(response, ct);
    }
}
