using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class ClinicsManager
{

    private List<Clinic> clinics;
    private List<Pet> pets;
    //private Pet pet;
    public ClinicsManager()
    {
        this.clinics = new List<Clinic>();
        this.pets = new List<Pet>();
       // this.Pet = pet;
    }

   // public Pet Pet { get; }
    public void AddClinic(Clinic clinic)
    {
        clinics.Add(clinic);
    }

    public void AddPetToList(Pet currentPet)
    {
        this.pets.Add(currentPet);
    }

    public bool AddPetToClinic(string petName, string clinicName)
    {
        var findedPet = pets.FirstOrDefault(p => p.Name == petName);
        var findedClinic = clinics.FirstOrDefault(c => c.Name == clinicName);
        var startedRoom = findedClinic.NumberOfRooms / 2;
        var totalRoom = findedClinic.NumberOfRooms;
        var currentRoom = totalRoom - 1;
        var corrector = 1;
        var jumpLeft = startedRoom - corrector;
        var jumpRight = startedRoom + corrector;
        

        if (findedClinic != null && findedPet != null)
        {
            if (findedClinic.petsInClinic[startedRoom] == null)
            {
                findedClinic.petsInClinic[startedRoom] = findedPet;
                return true;
            }
           
            while (currentRoom > 0)
            {
                if (jumpLeft < 0)
                {
                    jumpLeft = 0;
                }
                if (jumpRight >= totalRoom)
                {
                    jumpRight = totalRoom - 1;
                }

                if (findedClinic.petsInClinic[jumpLeft] == null)
                {
                    findedClinic.petsInClinic[jumpLeft] = findedPet;
                    return true;
                }
                jumpLeft--;
                if (jumpLeft < 0)
                {
                    jumpLeft = 0;
                }
                if (findedClinic.petsInClinic[jumpRight] == null)
                {
                    findedClinic.petsInClinic[jumpRight] = findedPet;
                    return true;
                }
                jumpRight++;
                if (jumpRight >= totalRoom)
                {
                    jumpRight = totalRoom - 1;
                }
                currentRoom--;
            }
        }
        return false;
    }

    public bool HasEmptyRooms(string clinicName)
    {
        var findedClinic = clinics.FirstOrDefault(c => c.Name == clinicName);
        if (findedClinic != null)
        {
            foreach (var room in findedClinic.petsInClinic)
            {
                if (room == null)
                {
                    return true;
                }
            }
            return false;
        }
        return false;
    }

    public bool RealiceClinic(string clinicName)
    {
        var findedClinic = clinics.FirstOrDefault(c => c.Name == clinicName);
        var centerRoom = findedClinic.NumberOfRooms / 2;

        if (findedClinic != null)
        {
            for (int i = centerRoom; i < findedClinic.petsInClinic.Length; i++)
            {
                if (findedClinic.petsInClinic[i] != null)
                {
                    findedClinic.petsInClinic[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < centerRoom; i++)
            {
                if (findedClinic.petsInClinic[i] != null)
                {
                    findedClinic.petsInClinic[i] = null;
                    return true;
                }
            }
        }

        return false;
    }

    public string Print(string clinicName)
    {
        var sb = new StringBuilder();
        var findedClinic = clinics.FirstOrDefault(c => c.Name == clinicName);
        if (findedClinic != null)
        {
            foreach (var pet in findedClinic.petsInClinic)
            {
                if (pet == null)
                {
                    sb.AppendLine("Room empty");
                }
                else
                {
                    sb.AppendLine(pet.ToString());
                }
            }
        }

        return sb.ToString().Trim();
    }

    public string Print(string clinicName, int currentRoom)
    {
        var findedClinic = clinics.FirstOrDefault(c => c.Name == clinicName);
        if (findedClinic != null)
        {
            var currentPet = findedClinic.petsInClinic[currentRoom -1];

            if (currentPet == null)
            {
                return $"Room empty";
            }
            return $"{currentPet.ToString()}";
        }

        return "Room empty";
    }
}

