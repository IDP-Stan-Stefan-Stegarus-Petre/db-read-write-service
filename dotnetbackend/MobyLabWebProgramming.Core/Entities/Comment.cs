using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

/// <summary>
/// This is an example for a comment entity, it will be mapped to a single table and each property will have it's own column except for entity object references also known as navigation properties.
/// </summary>
public class Comment : BaseEntity
{
    public int IdUser { get; set; }

    public int IdPost { get; set; }

    public string Content { get; set; } = default!;
}
