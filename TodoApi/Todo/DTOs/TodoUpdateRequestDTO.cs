using System.ComponentModel.DataAnnotations;
using TodoApi.Models;
using TodoApi.Todo.Models;
using TodoApi.User.Models;

namespace TodoApi.Todo.DTOs;

public class TodoUpdateRequestDTO
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public TodoStatus? Status { get; set; }
    
}