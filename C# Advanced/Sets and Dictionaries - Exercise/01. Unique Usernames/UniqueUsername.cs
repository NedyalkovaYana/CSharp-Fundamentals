namespace _01.Unique_Usernames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class UniqueUsername
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var uniqeNameCollection = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                uniqeNameCollection.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\r\n", uniqeNameCollection));
        }
    }
}
