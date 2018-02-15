using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Program
{
    static void Main()
    {
        List<Person> familyTree = new List<Person>();
       

         var searchingInfoForThisPerson = CreateFamilyTree(familyTree);

        PrintResult();
    }

    private static void PrintResult()
    {
        throw new NotImplementedException();
    }

    private static string CreateFamilyTree(List<Person> familyTree)
    {
        var searchingNameInfo = Console.ReadLine();
        var mainPerson = new Person();
        if (searchingNameInfo.Contains("/"))
        {
            mainPerson.Age = searchingNameInfo;
        }
        else
        {
            mainPerson.Name = searchingNameInfo;
        }
        familyTree.Add(mainPerson);

        var input = String.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            if (!input.Contains("-"))
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0] + " " + tokens[1];
                var age = tokens[2];

                //Search in Parent List
                var searchInParentList = familyTree.Where(f => f.Parents.Where(n => n.Name == name)).FirstOrDefault();
                if (searchInParentList != null)
                {
                    searchInParentList.age = age;
                    break;
                }
                var searchInParentListAge = familyTree.FirstOrDefault(p => p.age == age);
                if (searchInParentListAge != null)
                {
                    searchInParentListAge.name = name;
                    break;
                }

                //Search in Child List
                var searchChildName = familyTree.FirstOrDefault(c => c.name == name);
                if (searchChildName != null)
                {
                    searchChildName.age = age;
                    break;
                }
                var searchChildAge = childList.FirstOrDefault(c => c.age == age);
                if (searchChildAge != null)
                {
                    searchChildAge.name = name;
                    break;
                }

            }
            else
            {

                var tokens = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);              

                // only birthday inputs
                if (tokens[0].Contains("/") && tokens[1].Contains("/"))
                {
                    if (!familyTree.Any(f => f.Age == tokens[0]))
                    {
                        Person currentParent = SetParent(tokens);
                        SetChild(familyTree, currentParent, tokens[1]);
                    }



                    var currentChild = new Child(String.Empty, tokens[1]);
                   
                }
                // only names input
                else if (!tokens[0].Contains("/") && !tokens[1].Contains("/") && !tokens[2].Contains("/"))
                {
                    var currentParent = new Parent(tokens[0], String.Empty);
                    var currentChild = new Child(tokens[1], String.Empty);
                   

                }
                // left birhtday right name
                else if (tokens[0].Contains("/") && !tokens[1].Contains("/"))
                {
                    var currentParent = new Parent(String.Empty, tokens[0]);
                    var currentChild = new Child(tokens[1], String.Empty);
                   
                }
                // left name right birhtday
                else if (!tokens[0].Contains("/") && !tokens[1].Contains("/"))
                {
                    var currentParent = new Parent(tokens[0], String.Empty);
                    var currentChild = new Child(String.Empty, tokens[1]);
                   
                }

            }

        }

        return searchingNameInfo;
    }

    private static Person SetParent(string[] tokens)
    {
        var currentParent = new Person();
        currentParent.Age = tokens[0];
        return currentParent;
    }

    public static void SetChild(List<Person> familyTree, Person currentParent, string childAge)
    {
        if (!familyTree.Any(c => c.Age == childAge))
        {
            var currentChild = new Person();
            currentChild.Age = childAge;
            currentParent.Children.Add(currentChild);
        }
        else
        {
            var currentChild = familyTree.First(c => c.Age == childAge); ///????
        }
    }
}

