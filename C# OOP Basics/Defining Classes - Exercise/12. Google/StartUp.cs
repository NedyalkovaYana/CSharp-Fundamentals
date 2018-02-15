using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var personList = new List<Person>();

        var input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var inputTokens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var personName = inputTokens[0];
            var keyword = inputTokens[1];
            var currentPerson = personList.FirstOrDefault(p => p.Name == personName);
            if (currentPerson == null)
            {
                currentPerson = new Person(personName);
                personList.Add(currentPerson);
            }

            switch (keyword)
            {
                case "company":
                    var currentCompany = 
                        new Company(inputTokens[2], inputTokens[3], decimal.Parse(inputTokens[4]));
                    currentPerson.AddCompany(currentCompany);
                    break;
                case "parents":
                    var parent = new Parents(inputTokens[2], inputTokens[3]);
                    currentPerson.AddParents(parent);
                    break;
                case "pokemon":
                    var pokemon = new Pokemon(inputTokens[2], inputTokens[3]);
                    currentPerson.AddPokemon(pokemon);
                    break;
                case "children":
                    var child = new Children(inputTokens[2], inputTokens[3]);
                    currentPerson.AddChildren(child);
                    break;
                case "car":
                    var car = new Car(inputTokens[2], int.Parse(inputTokens[3]));
                    currentPerson.AddCar(car);
                    break;
            }
           
        }
        var personForPrint = Console.ReadLine();
        var person = personList.First(p => p.Name == personForPrint);
        if (person != null)
        {
            Console.WriteLine(person.ToString());
        }
    }
}

