using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public static class CommandInterpreter
{
    static Data<string> dates = new Data<string>();
    public static void Add(string element)
    {
       // var dates = new Data<string>();
        dates.Add(element);
    }

    public static void Remove(int index)
    {
        dates.Remove(index);
    }

    public static bool Contains(string element)
    {
        return dates.Contains(element);
    }

    public static string Max()
    {
        return dates.Max();
    }

    public static string Min()
    {
        return dates.Min();
    }

    public static string Print()
    {
        return dates.Print();
    }

    public static void Swap(int index, int index1)
    {
        dates.Swap(index, index1);
    }

    public static int Greater(string element)
    {
       return dates.CountGreaterThan(element);
    }

    public static void Sort()
    {
       Sorter<string> sorter = new Sorter<string>();
       dates.dates = sorter.Sort(dates.dates);
        
    }
}

