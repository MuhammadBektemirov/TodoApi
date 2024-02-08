using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoApi.User.Models;

public class UserModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    public string? Name { get; set; }

    public string Sign { get; set; }
}