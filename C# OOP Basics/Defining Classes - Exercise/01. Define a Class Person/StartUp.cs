using System;
using System.Reflection;
using System.Runtime.InteropServices;


class StartUp
{
    static void Main()
    {
        Type personType = typeof(Person);
        FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine(fields.Length);
    }
}

