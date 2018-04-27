using System;
using System.Collections.Generic;

public class Pizza
{
    private string pizzaName;
    public List<Topping> toppings;
    public Dough dough;
   

    public Pizza(string pizzaName)
    {
        this.PizzaName = pizzaName;
        this.toppings = new List<Topping>();
       
    }

    public string PizzaName
    {
        get { return pizzaName; }
        private set
        {
            if (String.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException
                    ("Pizza name should be between 1 and 15 symbols.");
            }
            pizzaName = value;
        }
    }
    public void AddTopping(Topping topping)
    { 
        if (toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.toppings.Add(topping);
    }

    public double GetTotalCalories()
    {
        var calories = dough.CalcCalories();

        foreach (var top in this.toppings)
        {
            calories += top.GetCalories();
        }
        return calories;
    }
}

