namespace TimeCapsule.WebApi.Contracts.Requests;

public class CreateTimeCapsuleRequest
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime TimeOfOpening { get; init; }
}
