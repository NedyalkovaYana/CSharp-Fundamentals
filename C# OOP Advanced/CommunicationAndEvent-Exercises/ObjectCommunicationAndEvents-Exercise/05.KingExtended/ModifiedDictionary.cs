
using System.Collections.Generic;

public class ModifiedDictionary : Dictionary<string, Solider>   
{
    public void HandleSoliderDeath(object sender, SoliderDeathEventArgs args)
    {
        this.Remove(args.Name);
    }
}

