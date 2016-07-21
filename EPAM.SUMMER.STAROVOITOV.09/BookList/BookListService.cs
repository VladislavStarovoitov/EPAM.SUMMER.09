using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop;

namespace BookList
{
    public class BookListService
    {
        private List<Book> _books = new List<Book>();

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();
            if (_books.Contains(book))
                throw new ArgumentException();
            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();
            if (!(_books.Remove(book)))
                throw new ArgumentException(); 
        }

        public Book FindBookByTag(Predicate<Book> match)
        {
            if (ReferenceEquals(match, null))
                throw new ArgumentNullException();
            return _books.Find(match);
        }

        public void SortBooksByTag(Comparison<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException();
            _books.Sort(comparer);
        }

        public void LoadBooks(IBookListStorage storage)
        {
            _books = storage.LoadBooks();
        }

        public void SaveBooks(IBookListStorage storage)
        {
            storage.SaveBooks(_books);
        }
    }
}
