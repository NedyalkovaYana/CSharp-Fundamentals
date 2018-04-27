using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Race> raceDict;
    private Dictionary<int, Car> carsDict;
    Garage garage; 

    public CarManager()
    {
        this.raceDict = new Dictionary<int, Race>();
        this.carsDict = new Dictionary<int, Car>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, 
        int horsepower, int acceleration, int suspension, int durability)
    {
        if (type == "Performance")
        {
            Car car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            carsDict.Add(id, car);
        }

        else
        {
            Car car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            carsDict.Add(id, car);
        }
    }

    public string Check(int id) //not check in dictionary
    {
        var carToCheck = carsDict[id];
        return carToCheck.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool, int goldTime)
    {
        switch (type)
        {
            case "TimeLimit":
                var timeRace = new TimeLimitRace(length, route, prizePool, goldTime);
                CheckIsRaceExist(id, timeRace);
                break;
            case "Circuit":
                var circuitRace = new CircuitRace(length, route, prizePool, goldTime);
                CheckIsRaceExist(id, circuitRace);
                break;

        }
    }
    public void Open(int id, string type, int length, string route, int prizePool)
    {
        //open 1 Drag 10 BeverlyHills 50000
        //Casual”, “Drag” or “Drift”.
        switch (type)
        {
            case "Drag":
                var dragRace = new DragRace(length, route, prizePool);
                CheckIsRaceExist(id, dragRace);
                break;
            case "Casual":
                var casualRace = new CasualRace(length, route, prizePool);
                CheckIsRaceExist(id, casualRace);
                break;
            case "Drift":
                var driftRace = new DriftRace(length, route, prizePool);
                CheckIsRaceExist(id, driftRace);
                break;
        }
    }

    private void CheckIsRaceExist(int id, Race race)
    {
        if (!raceDict.ContainsKey(id))
        {
            raceDict.Add(id, race);
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!garage.parkedCars.Contains(carId) && raceDict.ContainsKey(raceId) && carsDict.ContainsKey(carId))
        {
            var car = carsDict[carId];
            if (raceDict[raceId].GetType().Name == "TimeLimitRace")
            {
                if (raceDict[raceId].Participiants.Count >= 1)
                {
                    return;
                }
            }
           raceDict[raceId].Participiants.Add(car);
        }
    }

    public string Start(int id)
    {
        var currentRace = raceDict[id];
        if (currentRace.Participiants.Count <= 0)
        {
            return $"Cannot start the race with zero participants.";
        }
        else
        {
            raceDict.Remove(id);  //?
            return currentRace.Performance();
        }
       
        
    }

    public void Park(int id)
    {
        var carToPark = carsDict[id];
        bool isContans = false;
        foreach (var race in raceDict.Values)
        {
            if (race.Participiants.Contains(carToPark))
            {
                isContans = true;
                break;
            }
        }
        if (isContans == false)
        {
            garage.parkedCars.Add(id);
        }

    }

    public void Unpark(int id)
    {
        if (garage.parkedCars.Contains(id))
        {
            garage.parkedCars.Remove(id);
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var carId in garage.parkedCars)
        {
            var car = carsDict[carId];
            car.Horsepower += tuneIndex;
            car.Suspension += tuneIndex / 2;
            if (car.GetType().Name == "ShowCar")
            {
                car.Stars += tuneIndex;
            }
            else
            {
                car.AddOns.Add(addOn);
            }
        }
    }

}

