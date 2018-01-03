namespace _07.Fix_Emails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FixEmails
    {
        static void Main()
        {
            var emailsDict = new Dictionary<string, string>();

            while (true)
            {
                var name = Console.ReadLine();
                if (name.ToLower() == "stop")
                {
                    break;
                }

                var email = Console.ReadLine();

                if (email.Contains(".uk") || email.Contains(".us"))
                {
                    break;
                }

                if (!emailsDict.ContainsKey(name))
                {
                    emailsDict.Add(name, email);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, emailsDict.Select(kvp => $"{kvp.Key} -> {kvp.Value}")));
        }
    }
}
