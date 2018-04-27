using System;

namespace _01.MathOperations
{
    public class StartUp
    {
        public static void Main()
        {
            var mo = new global::MathOperations();
            Console.WriteLine(mo.Add(2, 3));
            Console.WriteLine(mo.Add(2.2, 3.3, 5.5));
            Console.WriteLine(mo.Add(2.2m, 3.3m, 4.4m));
        }
    }
}
