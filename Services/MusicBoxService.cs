using Microsoft.Extensions.Options;
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
        _usersCollection = database.GetCollection<User>(musicBoxDatabaseSettings.Value.UsersCollectionName);
    }
}