using System;
using System.IO;
using System.Text;
using System.Linq;

public class LogFile : ILogFile
{   
    private StringBuilder sb;
   
    public LogFile()
    {
        this.sb = new StringBuilder();

    }
    public int Size { get; private set; }

    private int GetLettersOnlySum(string message)
    {
      return message
            .Where(c => char.IsLetter(c))
            .Sum(c => c);
    }
    public void Write(string message)
    {
        this.
            sb.AppendLine(message);        
        this.Size += this.GetLettersOnlySum(message);
    }

    public override string ToString()
    {
        return this.sb.ToString().Trim();
    }   
}

