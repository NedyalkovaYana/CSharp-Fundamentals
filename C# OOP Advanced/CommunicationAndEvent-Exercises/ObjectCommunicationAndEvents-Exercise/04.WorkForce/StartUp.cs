
using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var jobsList = new List<Job>();
        var employesList = new List<Employee>();
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split();
            var command = tokens[0];

            switch (command)
            {
                case "Job":
                    var employeeToJob = employesList.FirstOrDefault(f => f.Name == tokens[3]);
                    if(employeeToJob == null)
                    {
                        continue;
                    }
                    var job = new Job(tokens[1], int.Parse(tokens[2]), employeeToJob);
                    jobsList.Add(job);
                    break;
                case "StandardEmployee":
                    employesList.Add(new StandartEmployee(tokens[1]));
                    break;
                case "PartTimeEmployee":
                    employesList.Add(new PartTimeEmployee(tokens[1]));
                    break;
                case "Pass":
                    foreach (var jobs in jobsList)
                    {
                        jobs.Update();
                       
                    }

                    for (int i = jobsList.Count - 1; i >= 0; i--)
                    {
                        if (jobsList[i].WorkHoursRequired <= 0)
                        {
                            jobsList.Remove(jobsList[i]);
                        }
                    }
                    break;
                case "Status":
                    foreach (var jobs in jobsList)
                    {
                        Console.WriteLine(jobs.ToString());
                    }
                    break;
            }

        }
    }
}

