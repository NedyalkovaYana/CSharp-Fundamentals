using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var employeeList = new List<Employee>();
        var line = int.Parse(Console.ReadLine());

        for (int i = 0; i < line; i++)
        {
            var employeeInfo = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var name = employeeInfo[0];
            var salary = decimal.Parse(employeeInfo[1]);
            var position = employeeInfo[2];
            var department = employeeInfo[3];
            string email = string.Empty;
            int age = -50;

            if (employeeInfo.Length > 4)
            {
                var ageOrEmail = employeeInfo[4];
                if (ageOrEmail.Contains("@"))
                {
                    email = employeeInfo[4];
                }
                else
                {
                    age = int.Parse(employeeInfo[4]);
                }

            }
            if (employeeInfo.Length > 5)
            {
                age = int.Parse(employeeInfo[5]);
            }

            var newEmployee = new Employee(name, salary, position, department);
            if (!String.IsNullOrEmpty(email))
            {
                newEmployee.Email = email;
            }
            if (age != -50)
            {
                newEmployee.Age = age;
            }

            employeeList.Add(newEmployee);
        }

        var result = employeeList
            .GroupBy(d => d.Department)
            .Select(d => new
            {
                Department = d.Key,
                AverageSalary = d.Average(e => e.Salary),
                Employee = d.OrderByDescending(s => s.Salary).ToList()
            })
            .OrderByDescending(a => a.AverageSalary)
            .FirstOrDefault();

        if (result != null)
        {
            Console.WriteLine($"Highest Average Salary: {result.Department}");
            foreach (var employee in result.Employee)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}

