using TodoApi.User.DTOs;

namespace TodoApi.User.Services.Interfaces;

public interface IUserService
{
    public Task<UserDTO> CreateUserAsync(UserSignInRequestDTO request);

    public Task<List<UserDTO>> GetUsersAsync();

    public Task<UserDTO?> GetUserAsync(UserSignInRequestDTO request);

    public Task<UserDTO?> UpdateUserAsync(string id, UserUpdateRequestDTO request);
    
    public Task? DeleteUserAsync(string id);
}