using System;

public class StartUp
{
    public static void Main()
    {
        var carInfo = Console.ReadLine().Split();
        var carFuelQuantity = double.Parse(carInfo[1]);
        var carsLitersPerKM = double.Parse(carInfo[2]);
        var car = new Car(carFuelQuantity, carsLitersPerKM);

        var truckInfo = Console.ReadLine().Split();
        var truckFuelQuantity = double.Parse(truckInfo[1]);
        var truckLittersPerKM = double.Parse(truckInfo[2]);
        var truck = new Truck(truckFuelQuantity, truckLittersPerKM);

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var data = Console.ReadLine().Split();
            var command = data[0];
            var vehicleModel = data[1];
            var distance = double.Parse(data[2]);

            switch (command)
            {
                case "Drive":
                    if (vehicleModel == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                    break;
                case "Refuel":
                    if (vehicleModel == "Car")
                    {
                        car.Refueled(distance);
                    }
                    else
                    {
                        truck.Refueled(distance);
                    }
                    break;
            }
        }
        Console.WriteLine(car.ToString());
        Console.WriteLine(truck.ToString());
    }
}

