using System;

public class ConosoleWriter : IWriter
{
    public void WriteLine(string message) => Console.WriteLine(message);
}

