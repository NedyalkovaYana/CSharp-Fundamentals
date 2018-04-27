using System;
using System.Runtime.ExceptionServices;

public class StartUp
{
    public  static void Main()
    {
        var input1 = Console.ReadLine().Split();
        var name1 = input1[0] + " " + input1[1];
        var adress = input1[2];
        var tuple1 = new Tuple<string, string>(name1, adress);

        var input2 = Console.ReadLine().Split();
        var name2 = input2[0];
        var int1 = int.Parse(input2[1]);
        var tuple2 = new Tuple<string, int>(name2, int1);

        var input3 = Console.ReadLine().Split();
        var bankName = int.Parse(input3[0]);
        var balance = double.Parse(input3[1]);
        var tuple3 = new Tuple<int, double>(bankName, balance);

        
        Console.WriteLine(tuple1.Print());
        Console.WriteLine(tuple2.Print());
        Console.WriteLine(tuple3.Print());
    }
}

