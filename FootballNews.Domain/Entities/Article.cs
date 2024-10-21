using FootballNews.Domain.Interfaces;

namespace FootballNews.Domain.Entities;

public class Article : IArticle
{
    public Article(string title, string content, string url, string source, DateTime publishedDate)
    {
        Title = title;
        Content = content;
        Url = url;
        Source = source;
        PublishedDate = publishedDate;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Url { get; set; }
    public string Source { get; set; }
    public bool Published { get; set; }
    public DateTime PublishedDate { get; set; }
    public DateTime FetchDate { get; set; }

    // Foreign key to Team
    public int TeamId { get; set; }
    public Team? Team { get; set; }
}