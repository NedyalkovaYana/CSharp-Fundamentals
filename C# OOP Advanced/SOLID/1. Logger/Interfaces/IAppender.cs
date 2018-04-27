public interface IAppender
{
   
    ILayout Layout { get; }
    ReportLevel ReportLevel { get; set; }
    void AppendMessage(string dateTime, string reportLevel, string message);
}

