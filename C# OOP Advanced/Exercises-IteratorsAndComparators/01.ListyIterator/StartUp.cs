using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();
        ListyIterator<string> collection;

        if (input.Length > 1)
        {
            collection = new ListyIterator<string>(input.Skip(1).ToArray());
        }
        else
        {
            collection = new ListyIterator<string>();
        }

        while (input[0] != "END")
        { 
            var command = input[0];

            try
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(collection.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(collection.NextIndex());
                        break;
                    case "Print":
                        Console.WriteLine(collection.Print());
                        break;
                }     
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            input = Console.ReadLine().Split();
        }
    }
}

