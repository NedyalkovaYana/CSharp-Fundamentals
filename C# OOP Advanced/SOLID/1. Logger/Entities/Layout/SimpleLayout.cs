public class SimpleLayout : ILayout
{
    //"<date-time> - <report level> - <message>"
    public string FormatMessage(string date, string reportLevel, string message)
    {
        return $"{date} - {reportLevel} - {message}";
    }
}

