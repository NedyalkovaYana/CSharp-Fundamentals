using System.Collections.Generic;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    public List<Car> Participiants;

    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participiants = new List<Car>();
    }

    public int PrizePool
    {
        get { return prizePool; }
        set { prizePool = value; }
    }
    public string Route
    {
        get { return route; }
        set { route = value; }
    }

    public int Length
    {
        get { return length; }
        protected set { length = value; }
    }
    public abstract string Performance();
}

