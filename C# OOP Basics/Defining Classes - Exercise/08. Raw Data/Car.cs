public class Car
{
    //model, engine, cargo and a collection of exactly 4 tires
    private string model;
    public Engine engine;
    public Cargo cargo;
    public Tire[] tires;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }
}

