using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

public class Controller
{
    private Appender[] appenders;
    private AppenderFactory appenderFactory;
    private LayoutFactory layoutFactory;
    public Controller()
    {       
        appenderFactory = new AppenderFactory();
        layoutFactory = new LayoutFactory();

    }
    internal void GetAppendersFromConsole()
    {
        var numberOfAppenders = int.Parse(Console.ReadLine());
        appenders = new Appender[numberOfAppenders];
        for (int i = 0; i < numberOfAppenders; i++)
        {

            var input = Console.ReadLine().Split();           

            ILayout currentLayout = layoutFactory.GetInstance(input[1]);
            Appender currentAppender = appenderFactory.GetAppender(input[0], currentLayout);
            

            if (input.Length > 2)
            {
                string enumName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input[2].ToLower());
                currentAppender.ReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), enumName);
            }

            this.appenders[i] = currentAppender;
     
        }
    }
    public void Run()
    {
        int appenderCount = int.Parse(Console.ReadLine());
        appenders = new Appender[appenderCount];

        for (int i = 0; i < appenderCount; i++)
        {
            string[] appenderInfo = Console.ReadLine().Split();
            ILayout currentLayout = layoutFactory.GetInstance(appenderInfo[1]);
            Appender currentAppender = appenderFactory.GetAppender(appenderInfo[0], currentLayout);

            if (appenderInfo.Length > 2)
            {
                string enumName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(appenderInfo[2].ToLower());
                currentAppender.ReportLevel = (ReportLevel) Enum.Parse(typeof(ReportLevel), enumName);
            }

            appenders[i] = currentAppender;
        }

        Logger myLogger = new Logger(appenders);

        
        var command = Console.ReadLine().Split('|');
        while (command[0] != "END")
        {
            var reportLevel = command[0];
            var time = command[1];
            var message = command[2];

            foreach (var appender in this.appenders)
            {
                appender.AppendMessage(time, reportLevel, message);
            }

            command = Console.ReadLine().Split('|');
        }
        Console.WriteLine(myLogger);
    }
    internal void ExecuteCommands()
    {
        var command = Console.ReadLine().Split('|');

        while (command[0] != "END")
        {
            var reportLevel = command[0];
            var time = command[1];
            var message = command[2];

            foreach (var appender in this.appenders)
            {
                appender.AppendMessage(time, reportLevel, message);
            }

            command = Console.ReadLine().Split('|');
        }
    }
    internal void PrintAppenders()
    {
        foreach (var appender in this.appenders)
        {
            Console.WriteLine(appender.ToString().Trim());
        }
    }
}

