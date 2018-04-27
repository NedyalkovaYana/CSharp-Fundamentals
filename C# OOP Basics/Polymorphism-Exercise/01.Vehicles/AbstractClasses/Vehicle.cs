public abstract class Vehicle : IVehicle
{
    public string Model { get; }
    public double FuelQuantity { get; protected set; }
    public double FuelConsumation { get; protected set; }

    protected Vehicle(double fuelQuantity, double fuelConsumation)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumation = fuelConsumation;
    }

    public virtual string Drive()
    {
        return "Drive";
    }

    public virtual void Refueled()
    {       

    }
    public virtual string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}

