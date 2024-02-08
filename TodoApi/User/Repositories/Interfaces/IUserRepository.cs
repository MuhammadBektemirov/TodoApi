using TodoApi.Models;
using TodoApi.User.Models;

namespace TodoApi.User.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<UserModel> CreateUserAsync(UserModel user);

    public Task<List<UserModel>> GetUsersAsync();

    public Task<UserModel?> GetUserAsync(UserModel model);

    public Task<UserModel?> GetUserById(string id);

    public Task<UserModel?> UpdateUserAsync(string id, UserModel user);
    
    public Task? DeleteUserAsync(string id);
}