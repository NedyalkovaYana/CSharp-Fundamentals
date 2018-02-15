using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var carsList = new List<Car>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var carInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var carModel = carInfo[0];

            var engineSpeed = int.Parse(carInfo[1]);
            var enginePower = int.Parse(carInfo[2]);

            var cargoWeight = double.Parse(carInfo[3]);
            var cargoType = carInfo[4];

            var tire1Pressure = double.Parse(carInfo[5]);
            var tire1Age = int.Parse(carInfo[6]);
            var tire2Pressure = double.Parse(carInfo[7]);
            var tire2Age = int.Parse(carInfo[8]);
            var tire3Pressure = double.Parse(carInfo[9]);
            var tire3Age = int.Parse(carInfo[10]);
            var tire4Pressure = double.Parse(carInfo[11]);
            var tire4Age = int.Parse(carInfo[12]);

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Tire[] tires = new Tire[4];
            tires[0] = new Tire(tire1Pressure, tire1Age);
            tires[1] = new Tire(tire2Pressure, tire2Age);
            tires[2] = new Tire(tire3Pressure, tire3Age);
            tires[3] = new Tire(tire4Pressure, tire4Age); 

            Car car = new Car(carModel, engine, cargo, tires);
            carsList.Add(car);
        }

        var cargoTypeForPrint = Console.ReadLine();
        var sortedCars = new List<Car>();
        if (cargoTypeForPrint == "fragile")
        {
            sortedCars = carsList
                .Where(c => c.cargo.Type == "fragile" 
                && c.tires.Any(t => t.Pressure < 1))
                .ToList();

        }
        else
        {
            sortedCars = carsList
                .Where(c => c.cargo.Type == "flamable"
                            && c.engine.Power > 250)
                .ToList();
        }

        foreach (var sortedCar in sortedCars)
        {
            Console.WriteLine($"{sortedCar.Model}");
        }
    }
}

