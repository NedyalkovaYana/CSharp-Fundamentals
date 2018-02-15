using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var inputHolidayInfo = Console.ReadLine()
            .Split(' ')
            .ToArray();

        var pricePerDay = decimal.Parse(inputHolidayInfo[0]);
        var numbersOfDays = int.Parse(inputHolidayInfo[1]);
        var season = inputHolidayInfo[2];
        string discount = null;
        if (inputHolidayInfo.Length == 4)
            discount = inputHolidayInfo[3];

        var price = new PriceCalculator(pricePerDay, numbersOfDays, season, discount);

        Console.WriteLine($"{price.CalcPriceForAllHolyday():f2}");
    }
}

