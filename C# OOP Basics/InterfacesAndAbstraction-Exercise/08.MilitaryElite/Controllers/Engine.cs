using System;
using System.Linq;
using System.Text;

public class Engine
{
    private SoldiersManager manager;
    private StringBuilder stat;

    public Engine()
    {
        this.manager = new SoldiersManager();
        this.stat = new StringBuilder();
    }

    public void Run()
    {
        var command = Console.ReadLine().Split();

        while (command[0] != "End" )
        {
            this.ExecuteCommand(command);
            command = Console.ReadLine().Split();

        }
        Console.WriteLine(this.stat.ToString().Trim());
    }

    private void ExecuteCommand(string[] command)
    {
        var id = command[1];
        var firstName = command[2];
        var lastName = command[3];
        double salary;
        string corps;
        string cmdResult;

        try
        {
            switch (command[0])
            {
                case "Private":
                    salary = double.Parse(command[4]);
                    cmdResult = this.manager.RegisterPrivate(id, firstName, lastName, salary);
                    this.stat.AppendLine(cmdResult);
                    break;

                case "LeutenantGeneral":
                    salary = double.Parse(command[4]);
                    cmdResult = this.manager.RegisterLeutenantGeneral(id, firstName, lastName, salary, command.Skip(5));
                    this.stat.AppendLine(cmdResult);
                    break;
                case "Engineer":
                    salary = double.Parse(command[4]);
                    corps = command[5];
                    cmdResult = this.manager.RegisterEngineer(id, firstName, lastName, salary, corps,
                        command.Skip(6).ToArray());
                    this.stat.AppendLine(cmdResult);
                    break;
                case "Commando":
                    salary = double.Parse(command[4]);
                    corps = command[5];
                    cmdResult = this.manager.RegisterCommando(id, firstName, lastName, salary, 
                        corps, command.Skip(6).ToArray());
                    this.stat.AppendLine(cmdResult);
                    break;
                case "Spy":
                    var codeNumber = int.Parse(command[4]);
                    cmdResult = this.manager.RegisterSpy(id, firstName, lastName, codeNumber);
                    this.stat.AppendLine(cmdResult);
                    break;
                    default:
                        break;
            }
        }
        catch (ArgumentException)
        {
            return;
        }
    }
}

