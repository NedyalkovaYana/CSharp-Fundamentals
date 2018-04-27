using System;
using System.Collections.Generic;

public class Clinic
{
    private int numberOfRooms;
    public string Name { get; private set; }
    public Pet[] petsInClinic;
    public Clinic(string name, int numberOfRooms)
    {
        this.Name = name;
        this.NumberOfRooms = numberOfRooms;
        this.petsInClinic = new Pet[numberOfRooms];
    }
    public int NumberOfRooms
    {
        get { return numberOfRooms; }
        private set
        {
            if (value % 2 == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            numberOfRooms = value;
        }
    }

}

