using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            var numbers =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            var myStack = new Stack<int>();

            for (int i = 0; i < commands[0] && i < numbers.Count; i++)
            {
                myStack.Push(numbers[i]);
            }

            for (int i = 0; i < commands[1] && numbers.Count > 0; i++)
            {
                myStack.Pop();
            }

            Console.WriteLine(myStack.Count == 0 ? "0" : myStack.Contains(commands[2]) ? "true" : $"{myStack.Min()}");
        }
    }
}
