using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;       
    }

    public void Run()
    {
        while (true)
        {
            var input = this.reader.ReadLine();
            var data = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            writer.WriteLine(this.commandInterpreter.ProcessCommand(data));

            if (input == "Shutdown")
            {
                return;
            }   
        }
    }
}
