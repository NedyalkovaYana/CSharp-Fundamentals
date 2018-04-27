using System;
using System.Collections.Generic;
using System.Text;

public class Logger : ILogger
{

    private IAppender[] appenders;

    public Logger(params IAppender[] appenders)
    {
        this.appenders = appenders;
    }

    private void Log(string data, string reportLevel, string message)
    {
        foreach (IAppender appender in appenders)
        {
            ReportLevel curentReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);
            if (appender.ReportLevel <= curentReportLevel)
            {
                appender.AppendMessage(data, reportLevel, message);
            }
        }
    }

    public void Error(string data, string message)
    {
        this.Log(data, "Error", message);
    }

    public void Info(string data, string message)
    {
        this.Log(data, "Info", message);
    }

    public void Critical(string data, string message)
    {
        this.Log(data, "Critical", message);
    }

    public void Fatal(string date, string message)
    {
        this.Log(date, "Fatal", message);
    }

    public void Warn(string date, string message)
    {
        this.Log(date, "Warn", message);
    }


    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Logger info");
        foreach (IAppender appender in appenders)
        {
            sb.AppendLine(appender.ToString());
        }

        return sb.ToString();
    }
}

