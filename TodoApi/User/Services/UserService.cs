using TodoApi.Mappers;
using TodoApi.Shared.Enums;
using TodoApi.Shared.Exceptions;
using TodoApi.User.DTOs;
using TodoApi.User.Repositories.Interfaces;
using TodoApi.User.Services.Interfaces;

namespace TodoApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDTO> CreateUserAsync(UserSignInRequestDTO request)
    {
        var createdUser = await _userRepository.CreateUserAsync(request.ToUserModel());

        return createdUser.ToUserDTO();
    }

    public async Task<List<UserDTO>> GetUsersAsync()
    {
        var userModels = await _userRepository.GetUsersAsync();

        return userModels.ToUserDTOs();
    }

    public async Task<UserDTO?> GetUserAsync(UserSignInRequestDTO requestDto)
    {
        var userModel = await _userRepository.GetUserAsync(requestDto.ToUserModel());

        if (userModel is null)
            throw new NotFoundException(
                ErrorCodeEnums.TODO_NOT_FOUND,
                $"User with email: {requestDto.Email} is not found.");

        return userModel.ToUserDTO();
    }
    
    public async Task<UserDTO?> UpdateUserAsync(string id, UserUpdateRequestDTO request)
    {
        var userModel = await _userRepository.GetUserById(id);
    
        if (userModel is null)
        {
            throw new NotFoundException(
                ErrorCodeEnums.USER_NOT_FOUND,
                $"User with id {id} is not found");
        }
    
        var updatedUserModel = await _userRepository.UpdateUserAsync(id, request.ToUserModel(userModel));
    
        return updatedUserModel.ToUserDTO();
    }

    public async Task? DeleteUserAsync(string id)
    {
        var userModel = await _userRepository.GetUserById(id);
    
        if (userModel is null)
        {
            throw new NotFoundException(
                ErrorCodeEnums.USER_NOT_FOUND,
                $"User not found.");
        }
    
        await _userRepository.DeleteUserAsync(id);
    }
}   