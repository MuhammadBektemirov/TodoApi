using System.ComponentModel.DataAnnotations;

namespace TodoApi.User.DTOs;

public class UserSignInRequestDTO
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}