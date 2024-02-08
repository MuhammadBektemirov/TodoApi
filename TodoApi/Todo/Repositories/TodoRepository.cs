using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TodoApi.Models;
using TodoApi.Shared;
using TodoApi.Todo.Models;
using TodoApi.Todo.Repositories.Interfaces;

namespace TodoApi.Todo.Repositories;

public class TodoRepository : AbstractMongoDB<TodoModel>, ITodoRepository
{
    private const string COLLECTION_NAME = "todo-models";

    public TodoRepository(
        IOptions<MongoClientOptions> settings, 
        IMongoClient client) : base(
        settings.Value, 
        client,
        COLLECTION_NAME) { }

    public async Task<TodoModel> CreateTodoAsync(TodoModel todo)
    {
        await _collection.InsertOneAsync(todo);

        return todo;
    }

    public async Task<List<TodoModel>> GetTodosAsync(string userId)
    {
        return await _collection.FindAsync(t => t.UserId == userId).Result.ToListAsync();
    }

    public async Task<TodoModel?> GetTodoAsync(string id)
    {
        return await _collection.FindAsync(t => t.Id == id).Result.FirstOrDefaultAsync();
    }
    
    public async Task<TodoModel?> UpdateTodoAsync(string id, TodoModel todo)
    {
        await _collection.ReplaceOneAsync(t => t.Id == id, todo);
    
        return await GetTodoAsync(id);
    }
    
    public async Task? DeleteTodoAsync(string id)
    {
        await _collection.DeleteOneAsync(t => t.Id == id);
    }
}