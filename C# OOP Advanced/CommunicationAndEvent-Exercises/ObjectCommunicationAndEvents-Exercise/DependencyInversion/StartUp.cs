
using System;
using System.Linq;
using System.Runtime.InteropServices;

public class StartUp
{
    public static void Main()
    {
        var input = string.Empty;
        var calculator = new PrimitiveCalculator();

        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split().ToList();
            if (tokens[0] == "mode")
            {
                calculator.ChangeStrategy(char.Parse(tokens[1]));
            }
            else
            {
                Console.WriteLine(calculator.PerformCalculation(int.Parse(tokens[0]), int.Parse(tokens[1])));
            }
        }
    }
}

