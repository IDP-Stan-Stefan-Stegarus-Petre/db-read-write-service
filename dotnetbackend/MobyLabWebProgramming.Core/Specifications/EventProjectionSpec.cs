using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class EventProjectionSpec : BaseSpec<EventProjectionSpec, Event, EventDTO>
{
    protected override Expression<Func<Event, EventDTO>> Spec => e => new()
    {
        Id = e.Id,
        Content = e.Content,
        Title = e.Title,
        Location = e.Location,
        Date = e.Date,
        User = new UserDTO
        {
            Id = e.UserCreator.Id,
            Name = e.UserCreator.Name,
            Email = e.UserCreator.Email,
            PhoneNumber = e.UserCreator.PhoneNumber,
            Role = e.UserCreator.Role
        }
    };

    public EventProjectionSpec(Guid id) : base(id)
    {
        Query.Include(e => e.UserCreator);
    }

    public EventProjectionSpec(string? search)
    {
        Query.Include(e => e.UserCreator);

        search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;
        if (search == null)
        {
            return;
        }

        var searchExpr = $"%{search.Replace(" ", "%")}%";
        Query.Where(e => EF.Functions.ILike(e.Content, searchExpr) || EF.Functions.ILike(e.Title, searchExpr));
    }
}
