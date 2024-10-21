using FootballNews.Domain.Entities;

namespace FootballNews.Domain.Interfaces;

public interface ITeam
{
    int Id { get; set; }
    string Name { get; set; }
    string? Icon { get; set; }
    int League { get; set; }
    string? Trainer { get; set; }
    string? Description { get; set; }

    ICollection<User>? Users { get; set; }
    ICollection<Article>? Articles { get; set; }
}