using System;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
    public string LastName
    {
        get { return this.lastName; }
        private set
        {
            
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException
                    ($"Expected upper case letter! Argument: {nameof(lastName)}");
            }
            if (value.Length < 3)
            {
                throw new ArgumentException
                    ($"Expected length at least 3 symbols! Argument: {nameof(lastName)}");
            }
            this.lastName = value;
        }
    }


    public string FirstName
    {
        get { return this.firstName; }
        private set
        {
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(this.firstName)}");
            }
            if (value.Length < 4)
            {
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: {nameof(this.firstName)}");
            }
            this.firstName = value;
        }
    }

}

