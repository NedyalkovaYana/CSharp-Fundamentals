using System;

public class Product
{
    private string name;
    private decimal price;

    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }
    public decimal Price
    {
        get { return price; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Money cannot be negative");
            }
            price = value;
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
}

