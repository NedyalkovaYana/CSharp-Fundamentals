public  class Car
{
    //car<carModel> <carSpeed>”
    private string model;
    private int speed;

    public Car(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }
    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public override string ToString()
    {
        return $"{this.Model} {this.Speed}";
    }
}

