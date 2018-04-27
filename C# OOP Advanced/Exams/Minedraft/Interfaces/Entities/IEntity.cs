public interface IEntity
{
    int ID { get; }

    double Durability { get; set; }

    double Produce();

    void Broke();
}