using System;

public class Program
{
    public static void Main()
    {
        try
        { 
            var inputStudentInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var firstStudentName = inputStudentInfo[0];
            var lastStudentName = inputStudentInfo[1];
            var facultyNumber = inputStudentInfo[2];

            var student = new Student(firstStudentName, lastStudentName, facultyNumber);
            Console.WriteLine(student.ToString());

            var inputWorkerInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var firstWorkerName = inputWorkerInfo[0];
            var lastWorkerName = inputWorkerInfo[1];
            var workerSalary = decimal.Parse(inputWorkerInfo[2]);
            var hourPerDay = decimal.Parse(inputWorkerInfo[3]);

            var worker = new Worker(firstWorkerName, lastWorkerName, workerSalary, hourPerDay);
            Console.WriteLine(worker.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    }
}

