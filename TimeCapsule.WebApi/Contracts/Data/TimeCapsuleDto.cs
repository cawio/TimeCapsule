namespace TimeCapsule.WebApi.Contracts.Data;

public class TimeCapsuleDto
{
    public string Id { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime TimeOfCreation { get; init; }
    public DateTime TimeOfOpening { get; init; }
}
