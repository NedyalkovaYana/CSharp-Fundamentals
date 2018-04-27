using System;
using System.Text;

public class Worker : Human
{
    private const int MinHour = 1;
    private const int MaxHours = 12;

    private decimal weekSalary;
    private decimal workHourPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHourPerDay) 
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHourPerDay = workHourPerDay;
    }
    public decimal WorkHourPerDay
    {
        get { return this.workHourPerDay; }
        private set
        {
            if (value < MinHour || value > MaxHours)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(workHourPerDay)}");
            }
            this.workHourPerDay = value;
        }
    }       

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        private set
        {
            if (value <= 10)
            {
                throw new ArgumentException
                    ($"Expected value mismatch! Argument: {nameof(WeekSalary)}");
            }
            this.weekSalary = value;
        }
    }

    private decimal GetSalaryPerHour()
    {
        return this.WeekSalary /(this.WorkHourPerDay * 5);
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}")
            .AppendLine($"Week Salary: {this.WeekSalary:f2}")
            .AppendLine($"Hours per day: {this.WorkHourPerDay:f2}")
            .AppendLine($"Salary per hour: {this.GetSalaryPerHour():f2}");

        return sb.ToString();
    }
}

