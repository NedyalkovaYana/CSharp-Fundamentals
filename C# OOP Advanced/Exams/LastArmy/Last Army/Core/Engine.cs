using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private IReader reader;
    private IWriter writer;
    private IGameController gameController;
    private bool isRunning;
    public Engine(IReader reader, IWriter writer, IGameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
        this.isRunning = false;
    }

    public void Run()
    {
        this.isRunning = true;

        while (isRunning)
        {
            var input = reader.ReadLine();

            if (input == OutputMessages.InputTerminateString)
            {
                isRunning = false;
                continue;
            }

            try
            {
                gameController.ProcessCommand(input);
            }
            catch (ArgumentException ex)
            {
              this.writer.StoreMessages(ex.Message);
            }
        }

       this.gameController.ProduceSummary();
        this.writer.WriteLine(this.writer.StoredMessages().Trim());
    }

}

