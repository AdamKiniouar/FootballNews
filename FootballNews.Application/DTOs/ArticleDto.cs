using System.Text.Json.Serialization;

namespace FootballNews.Application.DTOs;

public class ArticleDto
{
    public ArticleDto(string title, string content, string url, string source, DateTime publishedDate)
    {
        Title = title;
        Content = content;
        Url = url;
        Source = source;
        PublishedDate = publishedDate;
    }

    [JsonIgnore]
    public int Id { get; set; }
    public int TeamId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Url { get; set; }
    public string Source { get; set; }
    public DateTime PublishedDate { get; set; }
}