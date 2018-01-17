namespace _05.Filter_By_Age___another_solution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            var people = GetPeople();

            var olderOrYounger = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(olderOrYounger, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);
            InvokePrinter(people, tester, printer);
        }

        static void InvokePrinter(Dictionary<string, int> people, 
            Func<int, bool> tester, 
            Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "age":
                    return kvp => Console.WriteLine($"{kvp.Value}");
                case "name":
                    return kvp => Console.WriteLine($"{kvp.Key}");
                case "name age":
                    return kvp => Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                    default: return null;
            }
        }

        static Func<int, bool> CreateTester(string olderOrYounger, int age)
        {
            switch (olderOrYounger)
            {
                case "older":
                    return n => n >= age;
                case "younger":
                    return n => n < age;
                    default: return null;
            }
        }

        static Dictionary<string, int> GetPeople()
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = inputs[0];
                var age = int.Parse(inputs[1]);

                dict[name] = age;
            }
            return dict;
        }
    }
}
