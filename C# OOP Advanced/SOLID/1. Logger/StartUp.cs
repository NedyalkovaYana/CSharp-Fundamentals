public  class StartUp
{
    public static void Main()
    {
        var controller = new Controller();
        controller.GetAppendersFromConsole();
        controller.ExecuteCommands();
        controller.PrintAppenders();

    }
}

