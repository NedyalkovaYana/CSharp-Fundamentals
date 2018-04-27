using System;
public class StarUp
{
    public static void Main()
    {
        try
        {
            var pizzaName = Console.ReadLine().Split(' ');
            var nameOfPizza = pizzaName[1];
            var pizza = new Pizza(nameOfPizza);

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split();
                var type = tokens[0];
                switch (type.ToLower())
                {
                    case "dough":
                        var flourType = tokens[1];
                        var tehnicq = tokens[2];
                        var weight = double.Parse(tokens[3]);
                        pizza.dough = new Dough(flourType, tehnicq, weight);
                        
                        break;
                    case "topping":
                        var topingType = tokens[1];
                        var weightTopping = double.Parse(tokens[2]);
                        pizza.AddTopping(new Topping(topingType, weightTopping));
                       // pizza.toppings.Add(new Topping(topingType, weightTopping));  
                        break;
                }
            }
            Console.WriteLine($"{pizza.PizzaName} - {pizza.GetTotalCalories():f2} Calories.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

