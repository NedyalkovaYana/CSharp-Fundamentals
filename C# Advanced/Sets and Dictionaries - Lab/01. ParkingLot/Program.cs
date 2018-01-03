namespace _01.ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            var carsInDict = new SortedDictionary<string, string>();
            var inputData = string.Empty;
            while ((inputData = Console.ReadLine()) != "END")
            {
                var tokens = inputData
                    .Split(new string[]{", "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (tokens.Length < 2)
                {
                    break;
                }
                var direction = tokens[0];
                var carNumber = tokens[1];

                if (direction == "IN" && !carsInDict.ContainsKey(carNumber))
                {
                    //if (carsInDict.ContainsKey(carNumber))
                    //{
                    //    break;
                    //}
                    carsInDict.Add(carNumber, direction);
                }
                else if(direction == "OUT")
                {
                    if (carsInDict.ContainsKey(carNumber))
                    {
                        carsInDict.Remove(carNumber);
                    }
                }
            }
            if (carsInDict.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                
            }
            else
            {
                foreach (var car in carsInDict)
                {
                    Console.WriteLine($"{car.Key}");
                }
            }
        }
    }
}
