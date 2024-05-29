using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using RhizomaAlismatisBackend.Models;

namespace RhizomaAlismatisBackend.Services;

public class MusicBoxService
{
    private readonly IMongoCollection<User> _usersCollection;

    public MusicBoxService(IOptions<MusicBoxDatabase> musicBoxDatabaseSettings)
    {
        var client = new MongoClient(musicBoxDatabaseSettings.Value.ConnectionString);
        var database = client.GetDatabase(musicBoxDatabaseSettings.Value.DatabaseName);
        _usersCollection = database.GetCollection<User>(musicBoxDatabaseSettings.Value.UserCollectionName);
    }

    public async Task InsertUser(User user)
    {
       await _usersCollection.InsertOneAsync(user);
    }

    public async Task<User> GetUser(string userId)
    {
        return await _usersCollection.Find(user => user.Id == userId).FirstOrDefaultAsync();
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _usersCollection.Find(user => user.Email == email).FirstOrDefaultAsync();
    }
}