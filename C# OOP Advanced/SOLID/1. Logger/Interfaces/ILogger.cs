using System.Diagnostics;

public interface ILogger
{
    void Error(string data, string message);
    void Info(string data, string message);
    void Critical(string data, string message);
    void Fatal(string date, string message);
    void Warn(string date, string message);
}

