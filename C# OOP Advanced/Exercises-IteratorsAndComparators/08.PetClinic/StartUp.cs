
using System;

public class StartUp
{
    public static void Main()
    {
        var manager = new ClinicsManager();

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var commands = Console.ReadLine().Split();
            var command = commands[0];

            switch (command)
            {
                case "Create":
                    if (commands[1] == "Pet")
                    {
                        var name = commands[2];
                        var age = int.Parse(commands[3]);
                        var kind = commands[4];
                        var pet = new Pet(name, age, kind);
                        manager.AddPetToList(pet);
                    }
                    else
                    {
                        var clinicName = commands[2];
                        var rooms = int.Parse(commands[3]);
                        try
                        {
                            var clinic = new Clinic(clinicName, rooms);
                            manager.AddClinic(clinic);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;
                case "Add":
                    var petName = commands[1];
                    var clinicsName = commands[2];
                    Console.WriteLine(manager.AddPetToClinic(petName, clinicsName));
                    break;
                case "Release":
                    var nameOfClinic = commands[1];
                    Console.WriteLine(manager.RealiceClinic(nameOfClinic));
                    break;
                case "HasEmptyRooms":
                    var clinicN = commands[1];
                    Console.WriteLine(manager.HasEmptyRooms(clinicN));
                    break;
                case "Print":
                    if (commands.Length == 2)
                    {
                        var clinicName = commands[1];
                        Console.WriteLine(manager.Print(clinicName));
                    }
                    else
                    {
                        Console.WriteLine(manager.Print(commands[1], int.Parse(commands[2])));
                    }
                    break;
            }
        }
    }
}

