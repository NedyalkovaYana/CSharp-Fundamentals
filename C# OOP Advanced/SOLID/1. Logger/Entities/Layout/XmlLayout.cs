using System.Text;

public class XmlLayout : ILayout
{
    public string FormatMessage(string dateTime, string reportLevel, string message)
    {
        var sb = new StringBuilder();

        sb.AppendLine("<log>")
            .Append('\t')
            .Append("<date>")
            .Append(dateTime)
            .Append("</date>")
            .AppendLine()
            .Append('\t')
            .Append("<level>")
            .Append(reportLevel)
            .Append("</level>")
            .AppendLine()
            .Append('\t')
            .Append("<message>")
            .Append(message)
            .Append("</message>")
            .AppendLine()
            .AppendLine("</log>")
            .ToString().Trim();

        return sb.ToString().Trim();
    }
}

