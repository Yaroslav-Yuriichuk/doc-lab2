namespace DLL.Utils;

internal static class StringUtil
{
    private static readonly Random Random = new Random();

    public static string RandomString(int length,
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 ;.,?")
    {
        return new string(Enumerable
            .Range(0, length)
            .Select(_ => chars[Random.Next(0, chars.Length)])
            .ToArray());
    }
}