using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var engineList = new List<Engine>();
        var carsList = new List<Car>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            //Engine <Model> <Power> <Displacement> <Efficiency>”.
            var engineTokens = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var model = engineTokens[0];
            var power = int.Parse(engineTokens[1]);
            var displacement = 0;        
            Engine engine = null;

            if (engineTokens.Length == 2)
            {
                engine = new Engine(model, power);
                
            }
            else if (engineTokens.Length == 4)
            {
                var efficiency = engineTokens[3];
                displacement = int.Parse(engineTokens[2]);
                engine = new Engine(model, power, displacement, efficiency);
            }         
            else if (engineTokens.Length == 3 && int.TryParse(engineTokens[2], out displacement))
            {            
                engine = new Engine(model, power, displacement);
            }
            else 
            {              
                engine = new Engine(model, power, displacement, engineTokens[2]);
            }
            engineList.Add(engine);
        }

        int m = int.Parse(Console.ReadLine());
        for (int i = 0; i < m; i++)
        {
            //Car  “<Model> <Engine> <Weight> <Color>”, 
            var carInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Car car = null;
            var carModel = carInfo[0];
            Engine engine = engineList.First(e => e.model == carInfo[1]);
            var weigth = 0;
            if (carInfo.Length == 2)
            {
                car = new Car(carModel, engine);
            }
            else if (carInfo.Length == 4)
            {
                car = new Car(carModel, engine, int.Parse(carInfo[2]), carInfo[3]);
            }
            else if (carInfo.Length == 3 && int.TryParse(carInfo[2], out weigth))
            {
                 car = new Car(carModel, engine, weigth);
            }
            else
            {
                car = new Car(carModel, engine,  carInfo[2]);
            }
            carsList.Add(car);
        }

        foreach (var car in carsList)
        {
            Console.WriteLine($"{car.model}:");
            Console.WriteLine($"  {car.engine.model}:");
            Console.WriteLine($"    Power: {car.engine.power}");
            if (car.engine.displacement > 0 )
                Console.WriteLine($"    Displacement: {car.engine.displacement}");
            else
                Console.WriteLine($"    Displacement: n/a");
            
            Console.WriteLine($"    Efficiency: {car.engine.efficiency}");
            if (car.weight > 0)
                Console.WriteLine($"    Weight: {car.weight}");
            else
                Console.WriteLine($"    Weight: n/a");

            Console.WriteLine($"    Color: {car.color}");
        }
    }
}

