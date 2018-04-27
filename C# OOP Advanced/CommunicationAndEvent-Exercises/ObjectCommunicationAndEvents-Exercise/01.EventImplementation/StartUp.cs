
using System;
using System.Net.Mime;

public class StartUp
{
    public static void Main()
    {
        var dispatcher = new Dispatcher();
        var handler = new Handler(new ConsoleWriter());

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        var name = string.Empty;

        while ((name = Console.ReadLine()) != "End")
        {
            dispatcher.Name = name;
        }ch
    }
}
