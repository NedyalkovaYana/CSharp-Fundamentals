public interface IVehicle
{
    double FuelQuantity { get; }
    double TankCapacity { get; }
    double FuelConsumation { get; }
    string Drive(double distance);
    void Refueled(double fuelToRefuel);
}

