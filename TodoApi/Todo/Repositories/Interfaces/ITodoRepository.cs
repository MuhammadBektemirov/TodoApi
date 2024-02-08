using TodoApi.Todo.Models;

namespace TodoApi.Todo.Repositories.Interfaces;

public interface ITodoRepository
{
    public Task<TodoModel> CreateTodoAsync(TodoModel todo);

    public Task<List<TodoModel>> GetTodosAsync(string userId);

    public Task<TodoModel?> GetTodoAsync(string id);
    
    public Task<TodoModel?> UpdateTodoAsync(string id, TodoModel todo);
    
    public Task? DeleteTodoAsync(string id);

}