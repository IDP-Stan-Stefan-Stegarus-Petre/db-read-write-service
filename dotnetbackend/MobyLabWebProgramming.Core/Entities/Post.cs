namespace MobyLabWebProgramming.Core.Entities;

public class Post : BaseEntity
{
    public string Content { get; set; } = default!;

    public Guid UserCreatorId { get; set; }
    public User? UserCreator { get; set; }
}
