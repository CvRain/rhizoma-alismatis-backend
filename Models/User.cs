using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RhizomaAlismatisBackend.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string CreateTime { get; set; } = Utils.TimeStamp.GetUnixTimeStamp().ToString();
    public string LastLoginTime { get; set; } = string.Empty;
}