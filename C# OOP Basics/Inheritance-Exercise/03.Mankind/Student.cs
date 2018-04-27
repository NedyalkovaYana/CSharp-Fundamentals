using System;
using System.Text;

public class Student : Human
{
    private const int MinLength = 5;
    private const int MaxLength = 10;
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FasilityNumber = facultyNumber;
    }
    public string FasilityNumber
    {
        get
        {
            return this.facultyNumber;
        }

        private set
        {
            if (value.Length < MinLength || value.Length > MaxLength 
                || !IsValidFacultyNumber(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }
    private bool IsValidFacultyNumber(string value)
    {
        bool isValidFacultyNumber = true;
        foreach (char ch in value)
        {
            if (!char.IsLetterOrDigit(ch))
            {
                isValidFacultyNumber = false;
            }
        }

        return isValidFacultyNumber;
    }


    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"First Name: {this.FirstName}")
          .AppendLine($"Last Name: {this.LastName}")
          .AppendLine($"Faculty number: {this.FasilityNumber}");

        return sb.ToString();
    }
}

