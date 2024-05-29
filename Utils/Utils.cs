namespace RhizomaAlismatisBackend.Utils;

public abstract class TimeStamp
{
    public static long GetUnixTimeStamp()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    public static string UnixTimeStampToString(long unixTimeStamp)
    {
        return DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp).ToString("yyyy-MM-dd HH:mm:ss");
    }

    public static string GetTimeStampFormatString()
    {
        return DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
    }
}