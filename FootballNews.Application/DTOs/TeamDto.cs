namespace FootballNews.Application.DTOs;

public class TeamDto
{
    public TeamDto(string name, int league)
    {
        Name = name;
        League = league;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int League { get; set; }

}