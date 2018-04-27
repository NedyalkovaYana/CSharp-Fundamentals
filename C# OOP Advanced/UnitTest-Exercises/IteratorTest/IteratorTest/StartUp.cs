using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace IteratorTest
{
   public class StartUp
    {
        public static void Main()
        {
            IListIterator list = null;

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    var tokens = input.Split();

                    switch (tokens[0])
                    {
                        case "Create":
                            var collection = new List<string>(tokens.Skip(1));
                            list = new ListIterator(collection);
                            break;
                        case "Move":
                            Console.WriteLine(list.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(list.HasNext());
                            break;
                        case "Print":
                            Console.WriteLine(list.Print());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
