using System;
using System.Collections;
public class RandomList : ArrayList
{
    private Random random;

    public RandomList()
    {
       this.random = new Random();

    }

    public int RandomInteger()
    {
        return this.random.Next();
    }

    public int RandomString() => this.RandomInteger();

}

