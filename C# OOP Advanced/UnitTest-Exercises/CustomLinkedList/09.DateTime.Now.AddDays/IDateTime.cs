
using System;

public interface IDateTime
{
    DateTime Now();
    void AddDays(DateTime date, double addDays);
    TimeSpan SubstractDays(DateTime date, int daysToSubstract);
}

