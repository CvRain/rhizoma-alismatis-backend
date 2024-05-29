namespace RhizomaAlismatisBackend.Models;

public class MusicBoxDatabase
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string UserCollectionName { get; set; } = null!;
}