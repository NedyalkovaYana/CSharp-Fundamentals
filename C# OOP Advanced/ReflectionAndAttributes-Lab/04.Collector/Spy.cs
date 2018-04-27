﻿using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] namesofFields)
    {
        var findedClass = Type.GetType(investigatedClass);
        var findedFields = findedClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance
            | BindingFlags.Static | BindingFlags.Public);

        var classInstance = Activator.CreateInstance(findedClass, new object[] {});



        var sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {findedClass}");

        foreach (var field in findedFields.Where(f => namesofFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();

        var findedClass = Type.GetType(className);

        var classFildes = findedClass.
            GetFields
            (BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        var classPublicMethods = findedClass
            .GetMethods
            (BindingFlags.Instance | BindingFlags.Public);

        var classNonPublicMethods = findedClass
            .GetMethods
            (BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var field in classFildes)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        var sb = new StringBuilder();

        var classType = Type.GetType(investigatedClass);

        var classMethods =
            classType.
            GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        sb.AppendLine($"All Private Methods of Class: {investigatedClass}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in classMethods)
        {
            sb.AppendLine($"{method.Name}");
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string investigatedClass)
    {
        var sb = new StringBuilder();

        var classType = Type.GetType(investigatedClass);
        var classMethods = classType
            .GetMethods
            (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);


        foreach (var method in classMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in classMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}

