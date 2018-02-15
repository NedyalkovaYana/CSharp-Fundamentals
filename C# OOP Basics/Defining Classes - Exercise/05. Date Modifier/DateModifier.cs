using System;

public class DateModifier
{
    public static int CalculateDifferenceBetweenDays(string firstDate, string secondDate)
    {
        var diference = DateTime.Parse(firstDate) - DateTime.Parse(secondDate);
        return Math.Abs(diference.Days);
    }
}

