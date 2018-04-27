using System;

public class Engine
{
    CarManager manager = new CarManager();

    public void Run()
    {
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "Cops Are Here")
        {
            var data = input.Split();
            var command = data[0];

            switch (command)
            {
                case "register":
                    manager.Register(int.Parse(data[1]), data[2], data[3], 
                        data[4], int.Parse(data[5]), int.Parse(data[6]),
                        int.Parse(data[7]), int.Parse(data[8]), int.Parse(data[9]));
                    break;
                case "open":
                    if (data[2] == "TimeLimit" || data[2] == "Circuit")
                    {
                        manager.Open(int.Parse(data[1]), data[2], int.Parse(data[3]), data[4], int.Parse(data[5]), int.Parse(data[6]));
                    }
                    else
                    {
                        manager.Open(int.Parse(data[1]), data[2], int.Parse(data[3]), data[4], int.Parse(data[5]));
                    }                    
                    break;
                case "participate":
                    //participate 3 3
                    manager.Participate(int.Parse(data[1]), int.Parse(data[2]));
                    break;
                case "check":
                    //check 5                    
                    Console.WriteLine(manager.Check(int.Parse(data[1])).Trim());
                    break;
                case "start":
                    //start 1
                    Console.WriteLine(manager.Start(int.Parse(data[1])).Trim());
                    break;
                case "park":
                    //park 5
                    manager.Park(int.Parse(data[1]));
                    break;
                case "tune":
                    //tune 100 Nitrous
                    manager.Tune(int.Parse(data[1]), data[2]);
                    break;
                case "unpark":
                    manager.Unpark(int.Parse(data[1]));
                    break;              
            }
        }
    }
}

