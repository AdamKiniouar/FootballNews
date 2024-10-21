using FootballNews.Domain.Entities;

namespace FootballNews.Domain.Interfaces;

public interface IArticle
{
    int Id { get; set; }
    string Title { get; set; }
    string Content { get; set; }
    string Url { get; set; } 
    string Source { get; set; }
    bool Published { get; set; }
    DateTime PublishedDate { get; set; }
    DateTime FetchDate { get; set; }

    // Foreign key to Team
    int TeamId { get; set; } 
    Team Team { get; set; }
}