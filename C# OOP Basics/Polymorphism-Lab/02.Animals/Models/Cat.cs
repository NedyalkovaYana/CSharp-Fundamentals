
using System;

public class Cat : Animal, IAnimals
{
    public Cat(string name, string favoriteFood) 
    : base(name, favoriteFood)
    {
    }

    public override string ExplainMyself()
    {
        return string.Format(base.ExplainMyself() + $"{Environment.NewLine}MEEOW");
    }
}

