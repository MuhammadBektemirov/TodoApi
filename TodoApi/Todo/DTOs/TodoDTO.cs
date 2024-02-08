using TodoApi.Models;
using TodoApi.Todo.Models;
using TodoApi.User.Models;

namespace TodoApi.Todo.DTOs;

public class TodoDTO
{
    public string Id { get; set; }

    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public long CreatedAt { get; set; }
    
    public TodoStatus Status { get; set; }
    
    public string UserId { get; set; }
}