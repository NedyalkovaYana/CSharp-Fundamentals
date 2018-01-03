namespace _06.A_Miner_s_Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var resourse = new Dictionary<string, int>();

            var inputData = string.Empty;

            var count = 0;
            while (true)
            {
                inputData = Console.ReadLine();
                if (inputData.ToLower() == "stop")
                {
                    break;
                }
                if (!resourse.ContainsKey(inputData))
                {
                    resourse.Add(inputData, 0);
                }
                var amount = int.Parse(Console.ReadLine());
                resourse[inputData] += amount;
            }

            Console.WriteLine(string.Join(Environment.NewLine, resourse.Select(kvp => $"{kvp.Key} -> {kvp.Value}")));
        }
    }
}
