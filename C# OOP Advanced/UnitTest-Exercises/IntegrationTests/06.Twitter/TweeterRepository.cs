
using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

public class TweeterRepository : ITweetRepository
{
    private const string ServerFileName = "server.txt";
    private const string MessageSeparator = "<[<MessageSeparator>]>";
    private readonly string ServerFullPath = Path.Combine(Environment.CurrentDirectory, ServerFileName);

    public void SaveTweet(string content)
    {
        File.AppendAllText(this.ServerFullPath, $"{content}{MessageSeparator}");
    }
}

