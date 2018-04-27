
using System;

public class SoliderDeathEventArgs : EventArgs
{
    public SoliderDeathEventArgs(string name, EventHandler respondMethod)
    {
        this.Name = name;
        this.RespondMethod = respondMethod;
    }
    public string Name { get; set; }

    public EventHandler RespondMethod { get; private set; }
}

