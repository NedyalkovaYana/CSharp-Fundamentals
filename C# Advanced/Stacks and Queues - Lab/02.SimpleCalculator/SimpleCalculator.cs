namespace _02.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class SimpleCalculator
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();
            var numbers =new Stack<int>();
            var operands = new Stack<string>();

            foreach (var element in input)
            {
                if (element == "+" || element == "-")
                {
                    operands.Push(element);
                    continue;
                }

                numbers.Push(int.Parse(element));

            }
            if (numbers.Count == 0)
            {
                return;
            }

            PrintResult(numbers, operands);
        }

        static void PrintResult(Stack<int> numbers, Stack<string> operands)
        {
            var result = numbers.Pop();

            while (numbers.Count > 0)
            {
                result = CalculateNext(result, numbers, operands);
            }

            Console.WriteLine(result);
        }

        static int CalculateNext(int result, Stack<int> numbers, Stack<string> operands)
        {
            switch (operands.Pop())
            {
                case "+":
                    return result + numbers.Pop();
                    break;
                case "-":
                    return result - numbers.Pop();
                    break;
            }
            return result;
        }
    }
}
