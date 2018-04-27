using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<string> birthdays = GetInput();

        PrintBirthdays(birthdays);
    }

    private static void PrintBirthdays(List<string> birthdays)
    {
        var year = Console.ReadLine();
        var allEqualYears = new List<string>();
        foreach (var birthday in birthdays)
        {
            if (birthday.EndsWith(year))
            {
                allEqualYears.Add(birthday);
            }
        }

        Console.WriteLine($"{string.Join(Environment.NewLine, allEqualYears)}");
    }

    private static List<string> GetInput()
    {
        var pets = new List<Pet>();
        var citizens = new List<Citizen>();
        var birthdays = new List<string>();
        var data = string.Empty;
        while ((data = Console.ReadLine()) != "End")
        {
            var tokens = data.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var type = tokens[0];

            switch (type.ToLower())
            {
                case "citizen":
                    var citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    citizens.Add(citizen);
                    birthdays.Add(tokens[4]);
                    break;
                case "pet":
                    var pet = new Pet(tokens[1], tokens[2]);
                    pets.Add(pet);
                    birthdays.Add(tokens[2]);
                    break;
                default:
                    continue;
            }
        }

        return birthdays;
    }
}

