using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

public class StartUp
{
    public static void Main()
    {
        var personsList = new List<Person>();
        var productList = new List<Product>();
        try
        {
            var input = string.Empty;
            var count = 1;
            while ((input = Console.ReadLine()) != "END")
            {                
                if (input.Contains("="))
                {
                    if (count == 1)
                    {
                        var personInfo = input
                            .Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < personInfo.Length; i += 2)
                        {
                            var personName = personInfo[i];
                            var personMoney = decimal.Parse(personInfo[i + 1]);

                            var currentPerson = new Person(personName, personMoney);
                            personsList.Add(currentPerson);
                            count++;
                        }
                    }
                    else
                    {
                        var productInfo = input
                            .Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < productInfo.Length; i += 2)
                        {
                            var productName = productInfo[i];
                            var productPrice = decimal.Parse(productInfo[i + 1]);

                            var currentProduct = new Product(productName, productPrice);
                            productList.Add(currentProduct);
                            
                            count++;
                        }
                    }
                }
                else
                {
                    var inputPersonProduct = input
                        .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                    var personName = inputPersonProduct[0];
                    var productName = inputPersonProduct[1];

                    var findedPerson = personsList.FirstOrDefault(p => p.Name == personName);
                    var findedProduct = productList.FirstOrDefault(p => p.Name == productName);
                    if (findedPerson != null && findedProduct != null)
                    {
                        Console.WriteLine(
                        findedPerson.AddProduct(findedProduct));
                    }
                }
            }

            foreach (var person in personsList)
            {
                if (person.Bag.Count <= 0)
                    Console.WriteLine($"{person.Name} - Nothing bought");
                else
                {
                    var bags = new List<string>();
                    foreach (var product in person.Bag)
                    {
                        bags.Add(product.Name);
                    }
                    Console.WriteLine($"{person.Name} - {string.Join(", ", bags)}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

