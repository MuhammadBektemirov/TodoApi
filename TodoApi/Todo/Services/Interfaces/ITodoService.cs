using TodoApi.Todo.DTOs;
using TodoApi.User.Models;

namespace TodoApi.Todo.Services.Interfaces;

public interface ITodoService
{
    public Task<TodoDTO> CreateTodoAsync(string userId, TodoCreateRequestDTO request);
    
    public Task<List<TodoDTO>> GetTodosAsync(string userId);
    
    public Task<TodoDTO?> GetTodoAsync(string id);
    
    public Task<TodoDTO?> UpdateTodoAsync(string id, TodoUpdateRequestDTO request);
    
    public Task? DeleteTodoAsync(string id);
}