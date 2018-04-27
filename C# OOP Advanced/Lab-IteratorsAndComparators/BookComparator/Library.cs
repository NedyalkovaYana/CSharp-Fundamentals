using System.Collections;
using System.Collections.Generic;
public class Library : IEnumerable<Book>
{
    public SortedSet<Book> booksCollection;

    public Library(params Book[] books)
    {
        this.booksCollection = new SortedSet<Book>(books, new BookComparator());
    }
    public IEnumerator<Book> GetEnumerator() // връща нашия написан енумератор!!!
    {
        return this.booksCollection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();


    //private class LibraryIterator : IEnumerator<Book>
    //{
    //    private readonly IList<Book> books;
    //    private int currentIndex;
    //    public LibraryIterator(IEnumerable<Book> books)
    //    {
    //        this.books = new List<Book>();
    //        this.Reset();
    //    }
    //    public void Dispose()
    //    {
    //    }

    //    public bool MoveNext() => ++this.currentIndex < books.Count; //проверява дали има следващ елемент в колекцията


    //    public void Reset() => this.currentIndex = -1; // занулява


    //    public Book Current => this.books[this.currentIndex]; // подава текущия елемент

    //    object IEnumerator.Current => this.Current;

    //}
}

