using System.Collections.Generic;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reverseTeam;

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reverseTeam = new List<Person>();
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return this.firstTeam.AsReadOnly();}
    }

    public IReadOnlyCollection<Person> ReverseTeam
    {
        get { return this.reverseTeam.AsReadOnly(); }
    }
    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reverseTeam.Add(person);
        }
    }
}

