using TimeCapsule.WebApi.Contracts.Data;

namespace TimeCapsule.WebApi.Extensions.Responses;

public class TimeCapsuleResponse
{
    TimeCapsuleDto TimeCapsule { get; init; } = new();
}
