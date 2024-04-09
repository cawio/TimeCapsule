namespace TimeCapsule.Data.Models;

public class TimeCapsule
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime TimeOfCreation { get; init; }
    public DateTime TimeOfOpening { get; init; }
}
