
using System;
using System.Linq;

public class Misson : IMission
{
    private readonly string[] possibleStates = new string[] { "inProgress", "Finished" };
    public string CodeName { get; }
    public string State
    {
        get
        {
            return this.State;
        }
        private set
        {
            if (!this.possibleStates.Contains(value))
            {
                 throw new ArgumentException("Invalid mission state");
            }

            this.State = value;
        }}

    public Misson(string codeName, string state)
    {
        CodeName = codeName;
        State = state;
    }

    public void CompleteMission()
    {
        this.State = "Finished";
    }
    public override string ToString()
    {
        return $"Code Name: {CodeName} State: {State}";
    }
}

