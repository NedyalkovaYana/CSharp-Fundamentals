namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            Worker robot = new Robot("Robot", 10);
            Worker Employee = new Employee("io");
           ChargingStation cs = new ChargingStation(new Robot("Robot", 10));
        }
    }
}
