using FootballNews.Domain.Entities;

namespace FootballNews.Domain.Interfaces;

public interface IUser
{
    int Id { get; set; }
    string Username { get; set; }
    string Email { get; set; }
    string PasswordHash { get; set; }
    DateTime CreatedAt { get; set; }
    bool IsActive { get; set; }
    int TeamId { get; set; }
    Team? Team { get; set; }
}