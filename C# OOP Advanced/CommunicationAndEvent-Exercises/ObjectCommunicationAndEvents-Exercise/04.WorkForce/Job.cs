
using System;
using System.Security.Cryptography.X509Certificates;

public delegate void JobDoneEventHandler(object sender, JobEventArgs args);
public class Job
{
    public EventHandler JobDone;
    private IEmployee employee;
    private int workHoursRequired;

    public Job(string name, int workHoursRequired, IEmployee employee)
    {
        this.Name = name;
        this.WorkHoursRequired = workHoursRequired;
        this.employee = employee;
    }

    public string Name { get; }
    public int WorkHoursRequired
    {
        get { return this.workHoursRequired; }
        set
        {
            this.workHoursRequired = value;
            if (this.workHoursRequired <= 0)
            {
                this.workHoursRequired = 0;
                Console.WriteLine($"Job {this.Name} done!");
                this.JobDone?.Invoke(this, new JobEventArgs(this));
            }
        }
    }

    public void Update()
    {
        this.WorkHoursRequired -= this.employee.WorkHoursPerWeek;
    }

    public void OnJobDone(JobEventArgs args)
    {
        if (JobDone != null)
        {
            JobDone(this, args);
        }
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.WorkHoursRequired}";
    }
}

