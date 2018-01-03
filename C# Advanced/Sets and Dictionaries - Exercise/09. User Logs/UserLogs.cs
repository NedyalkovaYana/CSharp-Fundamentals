namespace _09.User_Logs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class UserLogs
    {
        static void Main()
        {
            //IP={IP.Address} message=’{A&sample&message}’ user={username}

            var usersDict = new SortedDictionary<string, Dictionary<string, int>>();

            var inputData = string.Empty;
            while ((inputData = Console.ReadLine()) != "end")
            {
                var tokens = inputData
                    .Split(new[] {' ', '='}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var user = tokens.Last();
                var ip = tokens[1];

                if (!usersDict.ContainsKey(user))
                {
                    usersDict[user] = new Dictionary<string, int>();
                   
                }
                if (!usersDict[user].ContainsKey(ip))
                {
                    usersDict[user].Add(ip, 0);
                }
                usersDict[user][ip] += 1;
            }

            foreach (var users in usersDict)
            {
                Console.WriteLine($"{users.Key}:" +
                                  $"{Environment.NewLine}" +
                                  $"{string.Join(", ", users.Value.Select(kvp => $"{kvp.Key} => {kvp.Value}"))}.");             
            }
        }
    }
}
