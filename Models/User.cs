using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RhizomaAlismatisBackend.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Icon { get; set; }
    public string CreateTime { get; set; }
    public string LastLoginTime { get; set; }
}