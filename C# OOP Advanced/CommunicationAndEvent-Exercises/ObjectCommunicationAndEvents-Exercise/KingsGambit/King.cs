
using System;
using System.Runtime.InteropServices;

public class King : IName
{
    public event EventHandler UnderAttack;
    public King(string name)
    {
        this.Name = name;
    }
    public string Name { get; }

    public void OnUnderAttack()
    {
        Console.WriteLine($"King {this.Name} is under attack!");
        if (UnderAttack != null)
        {
            UnderAttack(this, new EventArgs());
        }
    }
}

