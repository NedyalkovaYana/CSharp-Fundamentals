using System;

public class Dog : Animal, IAnimals
{
    public Dog(string name, string favoriteFood) 
        : base(name, favoriteFood)
    {
    }

    public override string ExplainMyself()
    {
        return string.Format(base.ExplainMyself() + $"{Environment.NewLine}DJAAF");
    }
}

