namespace MobyLabWebProgramming.Core.Entities;

public class Post : BaseEntity
{
    public string Content { get; set; } = default!;

    public Guid UserCreatorId { get; set; }

    public User UserCreator { get; set; } = default!;
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
}
