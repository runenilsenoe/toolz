namespace Tasks.Logging;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

public static class ConsoleLogger
{
    public static void Log(this string message, string level = "INFO")
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}");
    }
}