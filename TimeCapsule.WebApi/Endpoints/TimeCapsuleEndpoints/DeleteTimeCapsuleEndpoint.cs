using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using TimeCapsule.WebApi.Services;

namespace TimeCapsule.WebApi;

[HttpDelete("/time-capsules/{id}"), AllowAnonymous]
public class DeleteTimeCapsuleEndpoint(TimeCapsuleService capsuleService) : Endpoint<DeleteTimeCapsuleRequest>
{
    public override async Task HandleAsync(DeleteTimeCapsuleRequest request, CancellationToken ct)
    {
        var success = int.TryParse(request.Id, out var parsedId);
        if (!success)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var successfullyDeleted = await capsuleService.DeleteTimeCapsule(parsedId);

        if (!successfullyDeleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}
