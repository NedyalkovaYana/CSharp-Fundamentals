public abstract class Mission : IMission
{
    private string name;
    private double enduranceRequired;
    private double scoreToComplete;

    protected Mission(string name, double enduranceRequired, double scoreToComplete)
    {
        this.Name = name;
        this.EnduranceRequired = enduranceRequired;
        this.ScoreToComplete = scoreToComplete;
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }
    public double EnduranceRequired
    {
        get { return this.enduranceRequired; }
        protected set { this.enduranceRequired = value; }
    }
    public double ScoreToComplete
    {
        get { return this.scoreToComplete; }
        protected set { this.scoreToComplete = value; }
    }
    public abstract double WearLevelDecrement { get; }
}

