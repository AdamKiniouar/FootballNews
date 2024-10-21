using FootballNews.Domain.Interfaces;
using static BCrypt.Net.BCrypt;


namespace FootballNews.Domain.Entities;

public class User : IUser
{
    public User(string username, string email, string passwordHash)
    {
        Username = username;
        Email = email;
        PasswordHash = HashPassword(passwordHash);
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
    }

    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }

    // Foreign key to Team
    public int TeamId { get; set; }
    public Team? Team { get; set; }
}