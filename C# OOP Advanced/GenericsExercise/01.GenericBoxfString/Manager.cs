using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public static  class Manager
{
    public static void GenericBox()
    {
        var box = new Box<int>();
        box.Value = 12313;
        Console.WriteLine(box);

        var stringBox = new Box<string>();
        stringBox.Value = "life in a box";
        Console.WriteLine(stringBox);
    }

    public static void CenericBoxOfString()
    {
        var numbersOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numbersOfStrings; i++)
        {
            var currentInputString = Console.ReadLine();
            var box = new Box<string>();
            box.Value = currentInputString;
            Console.WriteLine(box.ToString());
        }
    }

    public static void GenericBoxOfInteger()
    {
        var numbersOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numbersOfStrings; i++)
        {
            var currentInt = int.Parse(Console.ReadLine());
            var box = new Box<int>();
            box.Value = currentInt;
            Console.WriteLine(box.ToString());
        }
    }

    public static void SwapMethodStrings()
    {
        var boxList = new List<Box<string>>();
        var num = int.Parse(Console.ReadLine());

        for (int i = 0; i < num; i++)
        {
            var currentString = Console.ReadLine();
            Box<string> boxElement = new Box<string>();
            boxElement.Value = currentString;
            boxList.Add(boxElement);
        }

        var swapIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Swap(boxList, swapIndexes[0], swapIndexes[1]);
        Console.WriteLine(string.Join(Environment.NewLine, boxList));
    }

    private static void Swap<T>(List<T> collecttion, int firstElement, int secondElement)
    {
        var temp = collecttion[secondElement];
        collecttion[secondElement] = collecttion[firstElement];
        collecttion[firstElement] = temp;
    }

    public static void SwapMethodOfIntegers()
    {
        var boxList = new List<Box<int>>();
        var num = int.Parse(Console.ReadLine());

        for (int i = 0; i < num; i++)
        {
            var currentInt = int.Parse(Console.ReadLine());
            Box<int> boxElement = new Box<int>();
            boxElement.Value = currentInt;
            boxList.Add(boxElement);
        }

        var swapIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Swap(boxList, swapIndexes[0], swapIndexes[1]);
        Console.WriteLine(string.Join(Environment.NewLine, boxList));
    }

    public static void GenericCountMethodStrings()
    {
        var numberOfElements = int.Parse(Console.ReadLine());
        var lisfOfElements = new List<Box<string>>();

        for (int i = 0; i < numberOfElements; i++)
        {
            var currentElement = Console.ReadLine();            
            lisfOfElements.Add(new Box<string>(currentElement));
        }

        var comparison = new Box<string>(Console.ReadLine());
        Console.WriteLine(CountGreaterThanComparisonValie(lisfOfElements, comparison));
    }

    private static int CountGreaterThanComparisonValie<T>(IEnumerable<T> collection, T comparison)
        where T : IComparable<T>
    {
        var count = 0;

        foreach (var element in collection)
        {
            if (element.CompareTo(comparison) > 0)
            {
                count++;
            }
        }

        return count;
    }

    public static void GenericCountMethodDoubles()
    {
        var numberOfElements = int.Parse(Console.ReadLine());
        var lisfOfElements = new List<Box<double>>();

        for (int i = 0; i < numberOfElements; i++)
        {
            var currentElement = double.Parse(Console.ReadLine());
            lisfOfElements.Add(new Box<double>(currentElement));
        }

        var comparison = new Box<double>(double.Parse(Console.ReadLine()));
        Console.WriteLine(CountGreaterThanComparisonValie(lisfOfElements, comparison));
    }
}

