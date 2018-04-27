
using System;

public class MyDateTime : IDateTime
{
    public DateTime Now() => DateTime.Now;

    public void AddDays(DateTime date, double addDays) =>
        date.AddDays(addDays);

    public TimeSpan SubstractDays(DateTime date, int daysToSubstract) =>
        date.Subtract(DateTime.Parse($"{daysToSubstract}", System.Globalization.CultureInfo.InvariantCulture));
}

