namespace _03.Count_Uppercase_Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class CountUppWords
    {
        public static void Main()
        {
            var text = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(string.Join(Environment.NewLine, text
                .Where(t => char.IsUpper(t[0]))));
        }
    }
}
