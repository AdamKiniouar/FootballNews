﻿namespace FootballNews.Application.DTOs;

public class RegisterUserDto
{
    public RegisterUserDto(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }

    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}