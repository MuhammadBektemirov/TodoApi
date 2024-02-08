using System.ComponentModel.DataAnnotations;
// using Microsoft.Build.Framework;
using TodoApi.Models;
using TodoApi.Todo.Models;
using TodoApi.User.Models;

namespace TodoApi.Todo.DTOs;

public class TodoCreateRequestDTO
{
    [Required]
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    [Required]
    public TodoStatus Status { get; set; }
}