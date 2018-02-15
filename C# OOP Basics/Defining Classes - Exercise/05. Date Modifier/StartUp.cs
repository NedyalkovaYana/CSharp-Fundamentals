
using System;

public class StartUp
{
    public static void Main()
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var differenceDays = DateModifier.CalculateDifferenceBetweenDays(firstDate, secondDate);
        Console.WriteLine(differenceDays);


    }
}

