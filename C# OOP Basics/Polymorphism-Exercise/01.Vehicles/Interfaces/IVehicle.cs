public interface IVehicle
{
    string Model { get; }
    double FuelQuantity { get; }
    double FuelConsumation { get; }
    string Drive();
    void Refueled();
}

