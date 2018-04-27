using System;
using System.Linq;
using System.Reflection;


public  class AppenderFactory
{
    public  Appender GetAppender(string appenderType, ILayout layout)
    {
        Type typeOfAppender = Assembly.GetExecutingAssembly().GetTypes()
            .FirstOrDefault(x => x.Name == appenderType);

        return (Appender) Activator.CreateInstance(typeOfAppender, layout);
    }
}

