using System;

public abstract class Animal
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Gender
    {
        get { return this.gender; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
            {
                throw new InvalidInputException();
            }
            this.gender = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        private set
        {
            if (value < 0 )
            {
                throw new InvalidInputException();
            }
            this.age = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
            {
                throw new InvalidInputException();
            }
            this.name = value;
        }
    }

    public abstract string ProduceSound();

    public override string ToString()
    {
        return string.Format("{0}{1}{2} {3} {4}{1}{5}",
            this.GetType().Name, // 0
            Environment.NewLine, // 1
            this.name, // 2
            this.age,  // 3
            this.gender, // 4
            this.ProduceSound()); // 5
    }
}

