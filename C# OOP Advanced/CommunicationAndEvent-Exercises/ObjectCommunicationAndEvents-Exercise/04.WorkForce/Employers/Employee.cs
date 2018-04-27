﻿
public abstract class Employee : IEmployee
{
    protected Employee(string name, int workHoursPerWeek)
    {
        this.Name = name;
        this.WorkHoursPerWeek = workHoursPerWeek;
    }
    public string Name { get; }
    public int WorkHoursPerWeek { get; }

}

