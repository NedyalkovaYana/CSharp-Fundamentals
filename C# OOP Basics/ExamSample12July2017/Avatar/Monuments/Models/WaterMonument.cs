public class WaterMonument : Monument
{
    private int waterAffinity;

    public int WaterAffinity
    {
        get { return waterAffinity; }
        protected set { waterAffinity = value; }
    }

    public WaterMonument(string name, int waterAffinity) 
        : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }
}
