using System;
public class StarUp
{
    public static void Main()
    {
        try
        {
            var pizzaInfo = Console.ReadLine().Split();
            var pizzaName = pizzaInfo[1];
            var numberOfTopping = int.Parse(pizzaInfo[2]);
            var pizza = new Pizza(pizzaName, numberOfTopping);

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
                        pizza.toppings.Add(new Topping(topingType, weightTopping));  
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

