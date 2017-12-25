namespace _01.Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var inputString = Console.ReadLine();
            var stringToCharrArr = inputString.ToCharArray();
            var stackString = new Stack<string>();

            for (int i = 0; i < stringToCharrArr.Length; i++)
            {
                stackString.Push(stringToCharrArr[i].ToString());
            }

            Console.WriteLine(string.Join("", stackString));
        }
    }
}
