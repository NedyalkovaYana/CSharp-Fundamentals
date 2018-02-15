using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var carsList = new List<Car>();

        int carsNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < carsNumber; i++)
        {
            var car = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var carModel = car[0];
            var carFuelAmount = decimal.Parse(car[1]);
            var carConsumForOneKM = decimal.Parse(car[2]);

            var currentCar = new Car(carModel, carFuelAmount, carConsumForOneKM);
            carsList.Add(currentCar);
        }

        var drivingCar = string.Empty;
        while ((drivingCar = Console.ReadLine()) != "End")
        {
            var carsInfo = drivingCar.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var carModel = carsInfo[1];
            var inputDistance = decimal.Parse(carsInfo[2]);

            var carToDrive = carsList.First(c => c.Model == carModel);

            carToDrive.Drive(inputDistance);
        }

        foreach (var car in carsList)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceToTravel}");
        }
      
    }
}

