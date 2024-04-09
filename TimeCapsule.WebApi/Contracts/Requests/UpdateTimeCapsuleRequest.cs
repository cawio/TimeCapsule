namespace TimeCapsule.WebApi;

public class UpdateTimeCapsuleRequest
{
    public string Id { get; init; } = string.Empty;
    public string? Title { get; init; }
    public string? Description { get; init; }
    public DateTime? OpenDate { get; init; }
}
