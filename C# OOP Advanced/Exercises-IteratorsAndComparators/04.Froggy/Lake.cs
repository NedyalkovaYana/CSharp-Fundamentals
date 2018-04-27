using System.Collections;
using System.Collections.Generic;
public class Lake : IEnumerable<int>
{

    public List<int> collection;

    public Lake(List<int> element)
    {
        this.collection = element;
    }


    public IEnumerator<int> GetEnumerator()
    {
        var evenPosition = new List<int>();
        var oddPosition = new List<int>();

        for (int i = 0; i < collection.Count; i++)
        {
            if (i % 2 == 0)
            {
                evenPosition.Add(collection[i]);
            }
            else
            {
                oddPosition.Add(collection[i]);
            }
        }

        collection = evenPosition;
        for (int i = oddPosition.Count - 1; i >= 0; i--)
        {
            collection.Add(oddPosition[i]);
        }

        return collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}

