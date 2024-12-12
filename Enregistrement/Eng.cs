using System;
using System.IO;

public class Eng : IEng
{
    private static readonly Lazy<Eng> _instance = new Lazy<Eng>(() => new Eng());
    private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "exceptions.log");

    private Eng() { }

    public static Eng Instance => _instance.Value;

    public void EngException(string message)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
        File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
    }
}
