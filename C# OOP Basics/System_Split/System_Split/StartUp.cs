﻿public class StartUp
{
    public static void Main()
    {
        var manager = new Manager();
        var engine = new Engine(manager);
        engine.Run();
    }
}

