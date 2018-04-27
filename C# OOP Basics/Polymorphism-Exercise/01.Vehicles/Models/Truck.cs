using System.Runtime.InteropServices;

public class Truck : Vehicle, IVehicle
{
    public const string Model = "Truck";
    public Truck(double fuelQuantity, double fuelConsumation) 
        : base(fuelQuantity, fuelConsumation)
    {
    }

    public string Drive(double distance)
    {
        var neededFuelToTravel = distance * (FuelConsumation + 1.6);
        if (neededFuelToTravel <= this.FuelQuantity)
        {
            this.FuelQuantity -= neededFuelToTravel;
            return $"Truck travelled {distance} km";
        }
        else
        {
            return $"Truck needs refueling";
        }
    }

    public void Refueled(double fuelToRefuel)
    {
        fuelToRefuel = (fuelToRefuel * 95) / 100;
        this.FuelQuantity += fuelToRefuel;
    }
}

