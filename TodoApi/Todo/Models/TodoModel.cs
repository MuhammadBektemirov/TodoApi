using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TodoApi.User.Models;

namespace TodoApi.Todo.Models;

public class TodoModel  
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public long CreatedAt { get; set; }
    
    public TodoStatus Status { get; set; }
    
    public string UserId { get; set; }
}

public enum TodoStatus
{
    NEW,
    
    DONE
}