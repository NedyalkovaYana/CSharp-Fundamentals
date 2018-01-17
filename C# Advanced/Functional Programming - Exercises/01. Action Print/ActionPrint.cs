namespace _01.Action_Print
{
    using System;
    using System.Collections.Generic;

    class ActionPrint
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split();

            Action<string[]> action = Print;
            action(input);
        }

        public static void Print(string[] input)
        {
            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
