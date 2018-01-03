using System.Security.AccessControl;

namespace _05.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var phoneBook = new Dictionary<string, string>();

            var inputData = string.Empty;

            while ((inputData = Console.ReadLine()) != "search")
            {
                var tokens = inputData
                    .Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var name = tokens[0];
                var phoneNumber = tokens[1];

                if (!phoneBook.ContainsKey(name))
                {
                    phoneBook.Add(name, String.Empty);
                }
                phoneBook[name] = phoneNumber;
            }
            
            while ((inputData = Console.ReadLine()) != "stop")
            {
                var isFindNumber = false;
                foreach (var name in phoneBook)
                {
                    if (name.Key == inputData)
                    {
                        Console.WriteLine($"{name.Key} -> {name.Value}");
                        isFindNumber = true;
                        break;
                    }

                }
                if (isFindNumber != true)
                {
                    Console.WriteLine($"Contact {inputData} does not exist.");
                }

            }
        }
    }
}
