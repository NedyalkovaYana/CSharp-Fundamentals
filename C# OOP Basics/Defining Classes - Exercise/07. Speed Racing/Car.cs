using System;
using System.Runtime;

class Car
{
    //Model, fuel amount, fuel consumption for 1 kilometer and distance traveled. 
    private string model;
    private decimal fuelAmount;
    private decimal fuelConsumptionForOneKM;
    private decimal distanceTraveled;

    public Car(string model, decimal fuelAmount, decimal fuelConsumptionForOneKm)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumptionForOneKM = fuelConsumptionForOneKm;
        this.distanceTraveled = 0;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public decimal FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public decimal FuelConsumptionForOneKM
    {
        get { return this.fuelConsumptionForOneKM; }
        set { this.fuelConsumptionForOneKM = value; }
    }

    public decimal DistanceToTravel
    {
        get { return this.distanceTraveled; }
        set { this.distanceTraveled = value; }
    }

    public void Drive(decimal inputDistance)
    {
        if (inputDistance <= this.FuelAmount / this.fuelConsumptionForOneKM)
        {
            this.distanceTraveled += inputDistance;
            this.FuelAmount -= this.fuelConsumptionForOneKM * inputDistance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

} 

