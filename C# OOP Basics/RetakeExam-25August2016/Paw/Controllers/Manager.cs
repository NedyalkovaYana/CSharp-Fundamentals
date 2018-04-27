using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class Manager
{
    private List<AdoptionCenter> adoptionCenters;
    private List<CleansingCenter> cleansingCenters;
    private List<CastrationCenter> castrationCenters;
    private Dictionary<string, string> sendingToClean;
    private List<Animal> adoptedAnimal;
    private Dictionary<string, string> sendingForCastrations;
    private List<string> castratedAnimals;

    public Manager()
    {
        this.adoptionCenters = new List<AdoptionCenter>();
        this.cleansingCenters = new List<CleansingCenter>();
        this.castrationCenters = new List<CastrationCenter>();
        this.sendingToClean = new Dictionary<string, string>();
        this.adoptedAnimal = new List<Animal>();
        this.sendingForCastrations = new Dictionary<string, string>();
        this.castratedAnimals = new List<string>();
    }

    public void RegisterCastractionCenter(List<string> args)
    {
        //RegisterCastrationCenter | Razor
        var name = args[1];
        castrationCenters.Add(new CastrationCenter(name));
    }

    public void RegisterAdoptionCenter(List<string> args)
    {
        //RegisterAdoptionCenter | Destiny
        var name = args[1];
        adoptionCenters.Add(new AdoptionCenter(name));
    }

    public void RegisterCleansingCenter(List<string> args)
    {
        //RegisterCleansingCenter | Hope
        var name = args[1];
        cleansingCenters.Add(new CleansingCenter(name));
    }

    public void RegisterDog(List<string> args) // not check in cleaningCenter
    {
        //RegisterDog | Sharo | 5 | 20 | Destiny
        var dogName = args[1];
        var age = int.Parse(args[2]);
        var amountOfCommands = int.Parse(args[3]);
        var center = args[4];

        var findedCenter = adoptionCenters.FirstOrDefault(a => a.Name == center);
        if (findedCenter != null)
        {
            var dog = new Dog(dogName, age, amountOfCommands);
            findedCenter.StoredAnimals.Add(dog);
        }
    }

    public void RegisterCat(List<string> args)
    {
        //RegisterCat | Mr.Whiskas | 1 | 1 | Sentinel
        var catName = args[1];
        var age = int.Parse(args[2]);
        var intelligence = int.Parse(args[3]);
        var center = args[4];

        var findedCenter = adoptionCenters.FirstOrDefault(a => a.Name == center);
        if (findedCenter != null)
        {
            var cat = new Cat(catName, age, intelligence);
            findedCenter.StoredAnimals.Add(cat);
        }
    }

    Dictionary<string, string> helperDictCastratedAnimals = new Dictionary<string, string>();
    public void SendForCastration(List<string> args)
    {
       // SendForCastration | Destiny | Razor
        var givenAdoptionCenter = args[1];
        var givenCastrationCenter = args[2];

        var adoptionCenter = adoptionCenters.First(a => a.Name == givenAdoptionCenter);
        var castrationCenter = castrationCenters.First(c => c.Name == givenCastrationCenter);

        foreach (var animalForCastrate in adoptionCenter.StoredAnimals)
        {
            castrationCenter.StoredAnimals.Add(animalForCastrate);
            helperDictCastratedAnimals.Add(animalForCastrate.Name, adoptionCenter.Name);
        }

        foreach (var animalForCastrate in castrationCenter.StoredAnimals)
        {
            adoptionCenter.StoredAnimals.Remove(animalForCastrate);
        }

    }

    public void SendForCleansing(List<string> args)
    {
        //SendForCleansing | Sentinel | Sanctuary
        var adoptionCenter = args[1];
        var cleansingCenter = args[2];

        var findedAdCenter = adoptionCenters.First(n => n.Name == adoptionCenter);
        var findedClCenter = cleansingCenters.First(n => n.Name == cleansingCenter);

        foreach (var animal in findedAdCenter.StoredAnimals)
        {
            if (animal.isClean == false)
            {
                sendingToClean.Add(animal.Name, findedAdCenter.Name);
                findedClCenter.StoredAnimals.Add(animal);
            }
        }

        foreach (var animal in findedClCenter.StoredAnimals)
        {
            findedAdCenter.StoredAnimals.Remove(animal);
        }
    }

    public void Castrate(List<string> args)
    {
        //Castrate | Razor
        var centerName = args[1];

        var castrationCenter = castrationCenters.First(c => c.Name == centerName);

        foreach (var castratedAnimal in castrationCenter.StoredAnimals)
        {
            castratedAnimals.Add(castratedAnimal.Name);
        }

        foreach (var animal in helperDictCastratedAnimals)
        {
            var animalName = animal.Key;
            var adoptionCenter = animal.Value;

            foreach (var adoption in adoptionCenters)
            {
                if (adoption.Name == adoptionCenter)
                {
                    var currentAnimal = castrationCenter.StoredAnimals.Find(a => a.Name == animalName);

                    adoption.StoredAnimals.Add(currentAnimal);
                }
            }
        }

        castrationCenter.StoredAnimals.Clear();
    }

    public string CastrationStatistics(List<string> args)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Paw Inc. Regular Castration Statistics")
            .AppendLine($"Castration Centers: {castrationCenters.Count}")
            .AppendLine($"Castrated Animals: {string.Join(", ", castratedAnimals)}");

        return sb.ToString().Trim();
    }

    public void Cleanse(List<string> args) //?????
    {
        //•	Cleanse | {cleansingCenterName}
        //Cleanse | Hope
        var returnedAnimal = new List<Animal>();
        var cleansingCenter = args[1];

        var findedCleancingCenter = cleansingCenters.First(c => c.Name == cleansingCenter);

        foreach (var cleanedAnimal in findedCleancingCenter.StoredAnimals)
        {
            cleanedAnimal.isClean = true;
            returnedAnimal.Add(cleanedAnimal);
        }

        findedCleancingCenter.StoredAnimals.Clear();
        var helperDict = new Dictionary<string, string>();
        foreach (var store in sendingToClean)
        { 
            var adoptionCenter = store.Value;
            var animalName = store.Key;

            foreach (var center in adoptionCenters)
            {
                if (adoptionCenter == center.Name)
                {
                    foreach (var animal in returnedAnimal)
                    {
                        if (animal.Name == animalName )
                        {
                            center.StoredAnimals.Add(animal);
                            helperDict.Add(animalName, adoptionCenter);
                        }
                    }
                    
                }
            }
        }

        foreach (var elements in helperDict)
        {
            var animalName = elements.Key;
            sendingToClean.Remove(animalName);
        }

        helperDict.Clear();
    }

    public void Adopt(List<string> args)
    {
        //•	Adopt | {adoptionCenterName}
        var adoptCenterName = args[1];

        var findedAdoptionCenter = adoptionCenters.First(a => a.Name == adoptCenterName);

        foreach (var animal in findedAdoptionCenter.StoredAnimals)
        {
            if (animal.isClean == true)
            {
                adoptedAnimal.Add(animal);
                //findedAdoptionCenter.StoredAnimals.Remove(animal);
            }
        }
        foreach (var animal in adoptedAnimal)
        {
            findedAdoptionCenter.StoredAnimals.Remove(animal);
        }
    }

    public string PawPaw()
    {
        var sb = new StringBuilder();

        var adoptedAnimalName = new List<string>();
        foreach (var animal in adoptedAnimal)
        {
            adoptedAnimalName.Add(animal.Name);
        }
        adoptedAnimalName.Sort();


        var cleansedAnimal = new List<Animal>();

        foreach (var center in adoptionCenters)
        {
            cleansedAnimal.AddRange(center.StoredAnimals.Where(a => a.isClean == true));
        }
        foreach (var animal in adoptedAnimal)
        {
            cleansedAnimal.Add(animal);
        }

        var cleansedAnimalName = new List<string>();

        foreach (var animal in cleansedAnimal)
        {
            cleansedAnimalName.Add(animal.Name);
        }
        cleansedAnimalName.Sort();

        var animalWaithingAdoption = 0;
        foreach (var center in adoptionCenters)
        {
            foreach (var animal in center.StoredAnimals)
            {
                if (animal.isClean == true)
                {
                    animalWaithingAdoption++;
                }
            }
        }
        var animalWaithingForClean = 0;
        foreach (var center in cleansingCenters)
        {
            animalWaithingForClean += center.StoredAnimals.Count;
        }

        string adoptResult = String.Empty;
        if (adoptedAnimalName.Count > 0)
        {
             adoptResult = $"{string.Join(", ", adoptedAnimalName)}";
        }
        else
        {
            adoptResult = $"None";
        }

        var cleanedResult = string.Empty;
        if (cleansedAnimalName.Count > 0)
        {
            cleanedResult = $"{string.Join(", ", cleansedAnimalName)}";
        }
        else
        {
            cleanedResult = "None";
        }
        sb.AppendLine($"Paw Incorporative Regular Statistics")
            .AppendLine($"Adoption Centers: {this.adoptionCenters.Count}")
            .AppendLine($"Cleansing Centers: {this.cleansingCenters.Count}")
            .AppendLine($"Adopted Animals: {adoptResult}")
            .AppendLine($"Cleansed Animals: {cleanedResult}")
            .AppendLine($"Animals Awaiting Adoption: {animalWaithingAdoption}")
            .AppendLine($"Animals Awaiting Cleansing: {animalWaithingForClean}");


        return sb.ToString().Trim();
    }
}

