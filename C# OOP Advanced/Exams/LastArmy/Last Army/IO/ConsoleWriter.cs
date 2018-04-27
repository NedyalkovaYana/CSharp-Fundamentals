using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder sb;

    public ConsoleWriter()
    {
        this.sb = new StringBuilder();
    }
    public void WriteLine(string output) => Console.WriteLine(output);
    public void StoreMessages(string inputText)
    {
        sb.AppendLine(inputText.Trim());
    }

    public string StoredMessages()
    {
        return this.sb.ToString().Trim();
    }
}
