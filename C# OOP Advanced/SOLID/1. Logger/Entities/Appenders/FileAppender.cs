using System;
using System.IO;
using System.Text;

public class FileAppender : Appender
{
    private const string FileName = "log.txt ";
    private readonly string filePath;
    public FileAppender(ILayout layout)
        : base(layout)
    {
        this.filePath = Path.Combine(Environment.CurrentDirectory, FileName);
        this.File = new LogFile();
    }

    public ILogFile File { get; set; }

    public override void AppendMessage(string dateTime, string reportLevel, string message)
    {
        var report = this.Layout.FormatMessage(dateTime, reportLevel, message);
        this.File.Write(report);
        System.IO.File.AppendAllText(this.filePath, report);
        System.IO.File.AppendAllText(this.filePath, Environment.NewLine);
        this.MessagesCount++;
    }
    public override string ToString()
    {
        return $"{base.ToString()}, File size: {this.File.Size}";
    }
}



