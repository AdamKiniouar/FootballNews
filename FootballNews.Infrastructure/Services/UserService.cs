using FootballNews.Application.Interfaces;
using FootballNews.Domain.Entities;
using FootballNews.Domain.IRepositories;
using FootballNews.Application.DTOs;

namespace FootballNews.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            var user = new User(registerUserDto.Username, registerUserDto.Email, registerUserDto.Password);

            await _userRepository.AddAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }

        public async Task<UserDto?> AuthenticateUserAsync(LoginDto loginDto)
        {
            if (loginDto.Username == null) return null;

            var user = await _userRepository.GetByUserNameAsync(loginDto.Username);
            if (BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email
                };
            }

            return null;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }
    }

}
