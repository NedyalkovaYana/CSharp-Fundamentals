public class Robot : IRobot
{
    public string Id { get; private set; }
    public string Model { get; private set; }

    public Robot(string id, string model)
    {
       this.Id = id;
        this.Model = model;
    }
}

