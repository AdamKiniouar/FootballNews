using FootballNews.Domain.Interfaces;

namespace FootballNews.Domain.Entities;

public class Team : ITeam
{
    public Team(string name, int league)
    {
        Name = name;
        League = league;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string? Icon { get; set; }
    public int League { get; set; }
    public string? Trainer { get; set; }
    public string? Description { get; set; }

    public ICollection<User>? Users { get; set; }
    public ICollection<Article>? Articles { get; set; }

}