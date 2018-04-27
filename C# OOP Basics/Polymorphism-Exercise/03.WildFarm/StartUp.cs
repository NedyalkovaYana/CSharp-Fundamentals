using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        FeedAnimals();

    }

    private static void FeedAnimals()
    {
        var animalList = new List<Animal>();
        var animalDetails = Console.ReadLine().Split().Where(s => s != string.Empty).ToArray();

        while (animalDetails[0] != "End")
        {
            var animal = SetAnimal(animalDetails);
            var foodDetails = Console.ReadLine().Split().Where(s => s != string.Empty).ToArray();
            var food = SetFood(foodDetails);

            Console.WriteLine(animal.MakeSound());

            try
            {
                animalList.Add(animal);
               animal.FeedAnimal(food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            animalDetails = Console.ReadLine().Split().Where(s => s != string.Empty).ToArray();
        }

        foreach (var animal in animalList)
        {
            Console.WriteLine(animal.ToString());
        }
    }

    private static Food SetFood(string[] foodDetails)
    {
        switch (foodDetails[0])
        {
            case "Vegetable":
                return new Vegetable(int.Parse(foodDetails.Last()));
            case "Meat":
                return new Meat(int.Parse(foodDetails.Last()));
            case "Fruit":
                return new Fruit(int.Parse(foodDetails.Last()));
            case "Seeds":
                return new Seeds(int.Parse(foodDetails.Last()));
            default:
                return null;
        }
    }

    private static Animal SetAnimal(string[] animalDetails)
    {
        var type = animalDetails[0];
        var name = animalDetails[1];
        var weight = double.Parse(animalDetails[2]);

        switch (type)
        {
            case "Owl":
                return new Owl(animalDetails[1], double.Parse(animalDetails[2]), 
                    double.Parse(animalDetails[3]));
            case "Hen":
                return new Hen(animalDetails[1], double.Parse(animalDetails[2]),
                    double.Parse(animalDetails[3]));
            case "Mouse":
                return new Mouse(name, weight, animalDetails[3]);
            case "Dog":
                return new Dog(name, weight, animalDetails[3]);
            case "Cat":
                return new Cat(name, weight, animalDetails[3], animalDetails[4]);
            case "Tiger":
                return new Tiger(name, weight, animalDetails[3], animalDetails[4]);
            default:
                return null;
        }
    }
}
