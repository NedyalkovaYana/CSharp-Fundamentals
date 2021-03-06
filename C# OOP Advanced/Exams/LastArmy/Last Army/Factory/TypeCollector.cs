﻿
using System;
using System.Linq;
using System.Reflection;

public class TypeCollector
{
    public Type[] GetAllInheritingTypes<T>()
        where T : class
    {
        Type parentType = typeof(T);
        if (!parentType.IsAbstract && !parentType.IsInterface)
        {
            throw new ArgumentException();
        }

        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => parentType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .ToArray();
    }
}

