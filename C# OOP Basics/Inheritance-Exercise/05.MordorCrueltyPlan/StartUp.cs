using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var player = new Player();
        player.Eat(Console.ReadLine()
            .Split()
            .Where(fn => fn != string.Empty)
            .Select(fn => FoodFactory.GetFood(fn)));

        Console.WriteLine(player);


        //var currentPoints = new MyFood();
        //var input = Console.ReadLine().ToLower().Trim().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        //for (int i = 0; i < input.Length; i++)
        //{
        //    var currentFood = input[i];
        //    currentPoints.AddFoodType(currentFood);
        //}
        //var mood = new MyMood();
        //Console.WriteLine($"{currentPoints.Points}");
        //Console.WriteLine($"{mood.GetMoodFace(currentPoints)}");
    }
}

