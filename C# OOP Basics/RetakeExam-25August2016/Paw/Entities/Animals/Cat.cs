
public class Cat : Animal
{
    private int intelligenceCoefficient;

    public Cat(string name, int age, int intelligenceCoefficient)
        : base(name, age)
    {
        this.IntelligentCoefficient = intelligenceCoefficient;
    }

    public int IntelligentCoefficient
    {
        get { return intelligenceCoefficient; }
        set { intelligenceCoefficient = value; }
    }
}

