using System.Collections.Generic;
public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        int comape = x.Title.CompareTo(y.Title);

        if (comape == 0)
        {
            comape = y.Year.CompareTo(x.Year);
        }

        return comape;
    }
}

