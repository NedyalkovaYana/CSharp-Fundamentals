using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;

namespace _11.Logs_Aggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LogsAggregator
    {
        class UserStat
        {
            public SortedSet<string> IpHIstory { get; set; }
            public int Duration { get; set; }
        }

        static void Main()
        {
            SortedDictionary<string, UserStat> logsDict = GetInput();

            foreach (var log in logsDict)
            {
                Console.WriteLine($"{log.Key}: {log.Value.Duration} " +
                                  $"[{string.Join(", ", log.Value.IpHIstory)}]");
            }
        }

        private static SortedDictionary<string, UserStat> GetInput()
        {
            int n = int.Parse(Console.ReadLine());

            var userData = new SortedDictionary<string, UserStat>();
            for (int i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var user = inputs[1];
                var ip = inputs[0];
                var duration = int.Parse(inputs[2]);

                if (!userData.ContainsKey(user))
                {
                    userData[user] = new UserStat
                    {
                        IpHIstory = new SortedSet<string>(),
                        Duration = 0
                    };
                }

                userData[user].IpHIstory.Add(ip);
                userData[user].Duration += duration;
            }
            return userData;
        }

    }
}

