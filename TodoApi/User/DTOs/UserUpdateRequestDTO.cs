namespace TodoApi.User.DTOs;

public class UserUpdateRequestDTO
{
    public string? Name { get; set; }
    
    public string? Email { get; set; }

    public string? Password { get; set; }

}