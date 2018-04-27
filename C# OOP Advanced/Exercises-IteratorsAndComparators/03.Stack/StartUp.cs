using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var input = string.Empty;

        var data = new Stack<string>();

        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);

            switch (tokens[0])
            {
                case "Push":
                    data.Push(tokens.Skip(1).ToArray());
                    break;
                case "Pop":
                    try
                    {
                        data.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, data));
    }
}

