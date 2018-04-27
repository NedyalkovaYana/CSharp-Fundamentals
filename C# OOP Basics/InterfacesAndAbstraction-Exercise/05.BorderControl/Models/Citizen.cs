using System.Collections.Generic;

public class Citizen : ICitizen
{
    public List<Citizen> detainedPersons;
    public string Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Citizen(string id, string name, int age)
    {
        this.Id = id;
        this.Name = name;
        this.Age = age;
    }  
}

