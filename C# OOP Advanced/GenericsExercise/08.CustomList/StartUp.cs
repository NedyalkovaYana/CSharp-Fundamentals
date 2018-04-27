using System;
using System.Runtime.InteropServices;
using System.Xml.Xsl;

public class StartUp
{
    public static void Main()
    {
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(' ');
            var command = tokens[0];
           

            switch (command)
            {
                case "Add":
                    var element = tokens[1];
                    CommandInterpreter.Add(element);
                    break;
                case "Remove":
                    int index = int.Parse(tokens[1]);
                    CommandInterpreter.Remove(index);
                    break;
                case "Contains":
                    element = tokens[1];
                    Console.WriteLine(CommandInterpreter.Contains(element));
                    break;
                case "Max":
                    Console.WriteLine(CommandInterpreter.Max());
                    break;
                case "Min":
                    Console.WriteLine(CommandInterpreter.Min());
                    break;
                case "Swap":
                    var index1 = int.Parse(tokens[1]);
                    var index2 = int.Parse(tokens[2]);
                    CommandInterpreter.Swap(index1, index2);
                    break;
                case "Greater":
                    var element1 = tokens[1];
                    Console.WriteLine(CommandInterpreter.Greater(element1));
                    break;
                case "Print":
                    Console.WriteLine(CommandInterpreter.Print());
                    break;

                case "Sort":
                    CommandInterpreter.Sort();                 
                    break;

            }
        }
    }
}

