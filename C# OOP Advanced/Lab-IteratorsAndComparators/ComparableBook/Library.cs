using System.Collections;
using System.Collections.Generic;
public class Library : IEnumerable<Book>
{
    public SortedSet<Book> booksCollection;

    public Library(params Book[] books)
    {
        this.booksCollection = new SortedSet<Book>(books);
    }
    public IEnumerator<Book> GetEnumerator() // връща нашия написан енумератор!!!
    {
        return booksCollection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}

