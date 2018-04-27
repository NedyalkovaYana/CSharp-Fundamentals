using System;

public abstract class Appender : IAppender
{
    protected Appender(ILayout layout)
    {
        this.Layout = layout;
        this.ReportLevel = 0;
    }
    public ILayout Layout { get; }
    public ReportLevel ReportLevel { get; set; }
    protected int MessagesCount { get; set; }
    public virtual void AppendMessage(string dateTime, string reportLevel, string message)
    {
        string formatedMessage = this.Layout.FormatMessage(dateTime, reportLevel, message);
        Console.WriteLine(formatedMessage);
        this.MessagesCount++;
    }

    public override string ToString()
    {
        return $"Appender type: " +
               $"{this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
               $"Report level: {this.ReportLevel.ToString().ToUpper()}, " +
               $"Messages appended: {this.MessagesCount}";
    }
}

