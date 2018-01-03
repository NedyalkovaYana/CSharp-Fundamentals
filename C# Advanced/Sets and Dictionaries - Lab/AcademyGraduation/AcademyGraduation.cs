using System.Globalization;

namespace AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AcademyGraduation
    {
        public static void Main()
        {
            var studentDict = new SortedDictionary<string, double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var studentName = Console.ReadLine();
                var arrayOfStudentGrades = Console.ReadLine()
                    .Split(new[] {' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => double.Parse(a, CultureInfo.InvariantCulture))
                    .ToArray();

                var studentGradeAverage = arrayOfStudentGrades.Average();

                if (!studentDict.ContainsKey(studentName))
                {
                    studentDict.Add(studentName, 0);
                }
                studentDict[studentName] += studentGradeAverage;
            }

            foreach (var student in studentDict)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value}");
            }
        }
    }
}
