

namespace _03.Custom_Min_Function
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class CustomMinFunction
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Func<double[], double> myFunc = GetMinNumber;
            var minNumber = myFunc(numbers);
            Console.WriteLine(minNumber);
        }

        static double GetMinNumber(double[] arg)
        {
            var min = double.MaxValue;
            foreach (var num in arg)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        }
    }
}
