using System;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    { 
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public virtual decimal Price
    {
        get { return this.price; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }


    public string Author
    {
        get { return this.author; }
        private set
        {
            var indexOfSpace = value.IndexOf(' ');
            if (indexOfSpace > 0 && indexOfSpace < value.Length - 1 
                && char.IsDigit(value[indexOfSpace + 1]))
            {
                throw new ArgumentException("Author not valid!");
            }
           this.author = value;
        }
    }


    public string Title
    {
        get { return this.title; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("Type: ").AppendLine(this.GetType().Name)
            .Append("Title: ").AppendLine(this.Title)
            .Append("Author: ").AppendLine(this.Author)
            .Append("Price: ").Append($"{this.Price:f2}")
            .AppendLine();

        return sb.ToString();
    }
}

