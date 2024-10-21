using FootballNews.Application.DTOs;

namespace FootballNews.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> RegisterUserAsync(RegisterUserDto registerUserDto);
    Task<UserDto?> AuthenticateUserAsync(LoginDto loginDto);
    Task<UserDto> GetUserByIdAsync(int id);
}