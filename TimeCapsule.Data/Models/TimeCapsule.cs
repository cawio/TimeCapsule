namespace TimeCapsule.Data.Models;

public class TimeCapsule
{
    public int Id { get; init; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime TimeOfCreation { get; init; }
    public DateTime TimeOfOpening { get; set; }
}
