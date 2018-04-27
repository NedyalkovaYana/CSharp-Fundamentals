public class Car : Vehicle, IVehicle
{
    public const string Model = "Car";
    public Car(double fuelQuantity, double fuelConsumation) 
        : base(fuelQuantity, fuelConsumation)
    {
    }

    public string Drive(double distance)
    {
        var neededFuelToTravel = (this.FuelConsumation + 0.9) * distance;
        if (neededFuelToTravel <= this.FuelQuantity)
        {
            this.FuelQuantity -= neededFuelToTravel;
            
            return $"Car travelled {distance} km";
            
        }
        else
        {
            return $"Car needs refueling";
        }
    }

    public void Refueled(double fuelToRefuel)
    {
        this.FuelQuantity += fuelToRefuel;
    }
    
}


