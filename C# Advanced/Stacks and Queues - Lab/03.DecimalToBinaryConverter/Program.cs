namespace _03.DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine(number);
               
            }
            else
            {
                Console.WriteLine(GetBinary(number));
            }
        }

        static string GetBinary(int number)
        {
            var binary = new Stack<int>();

            while (number > 0)
            {
                binary.Push(number % 2);
                number /= 2;
            }
            return string.Join(string.Empty, binary);
        }
    }
}
