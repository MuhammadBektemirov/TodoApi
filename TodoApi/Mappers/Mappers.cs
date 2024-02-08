using TodoApi.Shared.Utilities;
using TodoApi.Todo.DTOs;
using TodoApi.Todo.Models;
using TodoApi.User.DTOs;
using TodoApi.User.Models;

namespace TodoApi.Mappers;

public static class Mappers
{
    public static TodoModel ToTodoModel(this TodoCreateRequestDTO request, string userId)
    {
        return new TodoModel()
        {
            Title = request.Title,
            Status = request.Status,
            Description = request.Description,
            CreatedAt = DateTimeOffset.Now.ToUnixTimeSeconds(),
            UserId = userId
        };
    }

    public static TodoModel ToTodoModel(this TodoUpdateRequestDTO request, TodoModel model)
    {
        return new TodoModel()
        {
            Id = model.Id,
            Title = string.IsNullOrEmpty(request.Title) ? model.Title : request.Title,
            Status = request.Status ?? model.Status,
            Description = string.IsNullOrEmpty(request.Description) ? model.Description : request.Description,
            CreatedAt = model.CreatedAt,
            UserId = model.UserId
        };
    }

    public static TodoDTO ToTodoDTO(this TodoModel model, string userId)
    {
        return new TodoDTO()
        {
            Id = model.Id,
            Title = model.Title,
            Status = model.Status,
            Description = model.Description,
            CreatedAt = model.CreatedAt,
            UserId = userId
        };
    }

    public static TodoDTO ToTodoDTO(this TodoModel model)
    {
        return new TodoDTO()
        {
            Id = model.Id,
            Title = model.Title,
            Status = model.Status,
            Description = model.Description,
            CreatedAt = model.CreatedAt,
            UserId = model.UserId
        };
    }

    public static List<TodoDTO> ToTodoDTOs(this List<TodoModel> models, string userId)
    {
        return models.ConvertAll(model => model.ToTodoDTO(userId));
    }

    public static UserModel ToUserModel(this UserSignInRequestDTO request)
    {
        return new UserModel()
        {
            Sign = AuthUtilities.SHA256Converter(request.Email, request.Password)
        };
    }

    public static UserDTO ToUserDTO(this UserModel model)
    {
        return new UserDTO()
        {
            Id = model.Id,
            Name = model.Name
        };
    }

    public static List<UserDTO> ToUserDTOs(this List<UserModel> models)
    {
        return models.ConvertAll(model => model.ToUserDTO());
    }

    public static UserModel ToUserModel(this UserUpdateRequestDTO request, UserModel model)
    {
        return new UserModel()
        {
            Id = model.Id,
            Sign = request.Email is not null && request.Password is not null 
                ? AuthUtilities.SHA256Converter(request.Email, request.Password) 
                : model.Sign,
            Name = request.Name ?? model.Name
        };
    }
}