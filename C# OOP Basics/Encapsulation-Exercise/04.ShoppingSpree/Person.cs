using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bag;

    public List<Product> Bag
    {
        get { return bag; }
        private set { bag = value; }
    }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bag = new List<Product>();
    }

    public decimal Money
    {
        get { return money; }
        private set
        {
            if (value < 0)
            {
                throw  new ArgumentException($"{nameof(Money)} cannot be negative");
            }
            money = value;
        }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || value == " ")
            {
                throw new ArgumentException($"{nameof(Name)} cannot be empty");
            }
            name = value;
        }
    }

    public string AddProduct(Product product)
    {
        if (this.Money >= product.Price)
        {
            this.Money -= product.Price;
            bag.Add(product);
            return $"{this.Name} bought {product.Name}";
        }
        else
        {
            return $"{this.Name} can't afford {product.Name}";
        }
    }
}

