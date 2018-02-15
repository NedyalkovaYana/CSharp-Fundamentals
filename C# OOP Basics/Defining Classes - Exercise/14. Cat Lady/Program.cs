using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var catList = new List<Cat>();

        var inputCatDescription = string.Empty;
        while ((inputCatDescription = Console.ReadLine()) != "End")
        {
            var catDetails = inputCatDescription.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var catBreed = catDetails[0];
            var catName = catDetails[1];
            var catSpecific = catDetails[2];

            var currentCat = new Cat(catBreed, catName, catSpecific);
            catList.Add(currentCat);
        }
        var searchingCatName = Console.ReadLine();
        var findedCat = catList.FirstOrDefault(c => c.Name == searchingCatName);

        if (findedCat != null)
        {
            Console.WriteLine(findedCat.ToString());
        }
       
    }
}

