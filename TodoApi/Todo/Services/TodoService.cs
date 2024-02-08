using TodoApi.Mappers;
using TodoApi.Shared.Enums;
using TodoApi.Shared.Exceptions;
using TodoApi.Todo.DTOs;
using TodoApi.Todo.Repositories.Interfaces;
using TodoApi.Todo.Services.Interfaces;
using TodoApi.User.Models;

namespace TodoApi.Todo.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoDTO> CreateTodoAsync(string userId, TodoCreateRequestDTO request)
    {
        var createdTodoModel = await _todoRepository.CreateTodoAsync(request.ToTodoModel(userId));

        return createdTodoModel.ToTodoDTO(userId);
    }
    
    public async Task<List<TodoDTO>> GetTodosAsync(string userId)
    {
        var todoModels = await _todoRepository.GetTodosAsync(userId);
        return todoModels.ToTodoDTOs(userId);
    }

    public async Task<TodoDTO?> GetTodoAsync(string id)
    {
        var todoModel = await _todoRepository.GetTodoAsync(id);
    
        if (todoModel is null)
            throw new NotFoundException(
                ErrorCodeEnums.TODO_NOT_FOUND,
                $"Todo with id {id} is not found.");
    
        return todoModel.ToTodoDTO();
    }

    public async Task<TodoDTO?> UpdateTodoAsync(string id, TodoUpdateRequestDTO request)
    {
        var todoModel = await _todoRepository.GetTodoAsync(id);
    
        if (todoModel is null)
        {
            throw new NotFoundException(ErrorCodeEnums.TODO_NOT_FOUND,
                $"Todo with id {id} is not found.");
        }
    
        var updatedModel = await _todoRepository.UpdateTodoAsync(id, request.ToTodoModel(todoModel));
    
        return updatedModel.ToTodoDTO();
    }
    
    public async Task? DeleteTodoAsync(string id)
    {
        var todoModel = await _todoRepository.GetTodoAsync(id);
    
        if (todoModel is null)
        {
            throw new NotFoundException(
                ErrorCodeEnums.TODO_NOT_FOUND,
                $"Todo with id {id} is not found.");
        }
    
        await _todoRepository.DeleteTodoAsync(id);
    }
}