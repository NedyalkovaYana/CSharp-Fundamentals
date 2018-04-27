using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        var stones = Console.ReadLine()
            .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        var lake = new Lake(stones.ToList());

        var result = new List<int>();
        foreach (var stone in lake)
        {
            result.Add(stone);
        }

        Console.WriteLine(string.Join(", ", result));
    }
}

