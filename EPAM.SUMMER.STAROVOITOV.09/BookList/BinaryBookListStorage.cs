using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop;

namespace BookList
{
    class BinaryBookListStorage : IBookListStorage
    {
        public List<Book> LoadBooks()
        {
            throw new NotImplementedException();
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            throw new NotImplementedException();
        }
    }
}
