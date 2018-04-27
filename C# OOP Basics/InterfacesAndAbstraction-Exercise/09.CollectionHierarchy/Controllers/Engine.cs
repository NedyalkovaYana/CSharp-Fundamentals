using System;
using System.Text;

public class Engine
{
    private IAddCollection<string> addCollection;
    private IAddRemoveCollection<string> addRemoveCollection;
    private IMyList<string> myList;
    private StringBuilder resultingOutput;

    public Engine()
    {
        this.addCollection = new AddCollection<string>();
        this.addRemoveCollection = new AddRemoveCollection<string>();
        this.myList = new MyList<string>();
        this.resultingOutput = new StringBuilder();
    }

    public void Run()
    {
        var input = Console.ReadLine().Split();
        this.FillCollection(ref input, this.addCollection);
        this.FillCollection(ref input, this.addRemoveCollection);
        this.FillCollection(ref input, this.myList);

        var numbersOfRemovals = int.Parse(Console.ReadLine());
        this.RemoveOperation(numbersOfRemovals, this.addRemoveCollection);
        this.RemoveOperation(numbersOfRemovals, this.myList);

        Console.WriteLine(this.resultingOutput.ToString().Trim());
    }

    private void RemoveOperation(int numbersOfRemovals, IAddRemoveCollection<string> collection)
    {
        while (numbersOfRemovals > 0)
        {
            var removedElement = collection.Remove();
            this.resultingOutput.Append($"{removedElement} ");
            numbersOfRemovals--;
        }

        this.resultingOutput
            .Remove(this.resultingOutput.Length - 1, 1)
            .AppendLine();
    }

    private void FillCollection(ref string[] input, IAddCollection<string> collection)
    {
        foreach (var str in input)
        {
            var index = collection.Add(str);
            this.resultingOutput.Append($"{index} ");
        }

        this.resultingOutput
            .Remove(this.resultingOutput.Length - 1, 1)
            .AppendLine();
    }
}

