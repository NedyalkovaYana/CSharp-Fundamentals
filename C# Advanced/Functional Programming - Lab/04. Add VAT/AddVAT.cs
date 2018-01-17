namespace _04.Add_VAT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class AddVAT
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, numbers
                .Select(n => $"{n * 1.20 :f2}")));
        }

    }
}
