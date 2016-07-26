using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop;

namespace BookList
{
    public interface IBookListStorage
    {
        string FileName { get; }
        List<Book> LoadBooks();
        void SaveBooks(IEnumerable<Book> books);
    }
}
