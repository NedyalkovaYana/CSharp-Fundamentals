namespace _01.Reverse_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var inputs = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            var myStack = new Stack<long>();
            if (inputs.Count <= 0)
            {
                return;
            }
            for (int i = 0; i < inputs.Count; i++)
            {
                myStack.Push(inputs[i]);
            }

            while (myStack.Count > 0)
            {
                Console.Write(myStack.Pop() + " ");
                
            }
            Console.WriteLine();
        }
    }
}
