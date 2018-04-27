using System;
using System.Text;

public class ConsoleAppender : Appender
{
    public ConsoleAppender(ILayout layout) 
        : base(layout)
    {
    }
    public override void AppendMessage(string datetime, string reportLevel, string message)
    {
         Console.WriteLine(this.Layout.FormatMessage(datetime, reportLevel, message));
         this.MessagesCount++;
    }
}

