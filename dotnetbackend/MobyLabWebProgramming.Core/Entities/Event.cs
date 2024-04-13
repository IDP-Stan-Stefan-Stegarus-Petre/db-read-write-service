namespace MobyLabWebProgramming.Core.Entities;

public class Event : BaseEntity
{
    public string Content { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Date { get; set; } = default!;

    public Guid UserCreatorId { get; set; }
    public User? UserCreator { get; set; }
}
