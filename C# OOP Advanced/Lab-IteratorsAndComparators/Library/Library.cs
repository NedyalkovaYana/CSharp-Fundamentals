using System.Collections;
using System.Collections.Generic;
public class Library : IEnumerable<Book>
{
    public List<Book> booksCollection;

    public Library(params Book[] books)
    {
        this.booksCollection = new List<Book>(books);
    }
    public IEnumerator<Book> GetEnumerator() // връща нашия написан енумератор!!!
    {
        return new LibraryIterator(this.booksCollection);

    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex;
        public LibraryIterator(List<Book> books)
        {
            this.books = books;
            this.Reset();
        }
        public void Dispose()
        {
        }

        public bool MoveNext() => ++this.currentIndex < books.Count; //проверява дали има следващ елемент в колекцията


        public void Reset() => this.currentIndex = -1; // занулява


        public Book Current => this.books[this.currentIndex]; // подава текущия елемент

        object IEnumerator.Current => this.Current;

    }
}

