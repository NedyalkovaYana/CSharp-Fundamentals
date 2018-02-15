using System;
using System.Linq;
using System.Text;

public class Romb
{
    private int rombSize;

    public int RombSize => this.rombSize;

    public Romb(int size)
    {
        this.rombSize = size;
    }
    public string DrawRomb()
    {
        var romb = new StringBuilder();
        
        for (int i = 1; i <= rombSize; i++)
        {
            romb.AppendLine(string.Join(string.Empty, Enumerable.Repeat(" ", rombSize -i))
                          + string.Join(String.Empty, Enumerable.Repeat("* ", i)));
        }
        for (int i = rombSize - 1; i >= 1; i--)
        {
            romb.AppendLine(string.Join(String.Empty, Enumerable.Repeat(" ", rombSize - i))
                            + string.Join(String.Empty, Enumerable.Repeat("* ", i)));
        }
        return romb.ToString();
    }
}

