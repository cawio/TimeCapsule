using TimeCapsule.WebApi.Extensions.Responses;

namespace TimeCapsule.WebApi;

public class GetAllTimeCapsulesResponse
{
    public IEnumerable<TimeCapsuleResponse> TimeCapsules { get; set; } = [];

}
