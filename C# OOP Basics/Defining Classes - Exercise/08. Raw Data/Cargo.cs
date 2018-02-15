using System.Security.AccessControl;

public class Cargo
{
    private double weigth;
    private string type;
 
    public Cargo(double weigth, string type)
    {
        this.weigth = weigth;
        this.type = type;
    }

    public double Weigth
    {
        get { return this.weigth; }
        set { this.weigth = value; }
    }

    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }
}

