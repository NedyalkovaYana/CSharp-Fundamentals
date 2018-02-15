﻿using System;
using System.Collections.Generic;
using System.Linq;

class Family
{
    private List<Person> people;


    public Family()
    {
        this.people = new List<Person>();
    }

    public List<Person> People
    {
        get { return this.people; }
        set { this.people = value; }
    }
    public void AddMember(Person member)
    {
        this.people.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.people
            .OrderByDescending(a => a.Age)
            .FirstOrDefault();
    }
}

