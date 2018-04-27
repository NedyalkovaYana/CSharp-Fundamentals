
using System;
using System.Collections.Generic;

public class JobList : List<Job>
{
    public void OnJobDone(object sender, JobEventArgs e)
    {
        this.Remove(e.Job);
    }
}