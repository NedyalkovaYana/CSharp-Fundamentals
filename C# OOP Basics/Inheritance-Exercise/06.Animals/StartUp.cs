using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        var animalList = new List<Animal>();
        var inputInfo = string.Empty;

        while ((inputInfo = Console.ReadLine()) != "Beast!")
        {
            try
            {
                var animalType = inputInfo;
                var animalData = Console.ReadLine().Split(' ');
                var animalName = animalData[0];
                var animalAge = int.Parse(animalData[1]);                
                var animalGender = animalData[2];

                var animal = AnimalFactory.GetAnimal(animalType, animalName, animalAge, animalGender);
                animalList.Add(animal);
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException fex)
            {
                Console.WriteLine("Invalid input!");
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, animalList));
    }
}

