using System;
public class InvalidInputException :Exception
{
    private const string Message = "Invalid input!";

    public InvalidInputException()
        :base(Message)
    {
    }
}

