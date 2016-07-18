using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop;
using System.IO;

namespace BookList
{
    class BinaryBookListStorage : IBookListStorage
    {
        public string FileName { get; }

        public BinaryBookListStorage(string fileName)
        {
            if (fileName != string.Empty)
                FileName = fileName;
            throw new ArgumentException();
        }

        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.OpenRead(FileName)))
            {
                while (reader.PeekChar() > -1)
                {
                    string author = reader.ReadString();
                    string title = reader.ReadString();
                    int pages = reader.ReadInt32();
                    int year = reader.ReadInt32();
                    books.Add(new Book(author, title, pages, year));
                }
            }
            return books;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            using (var stream = File.OpenWrite(FileName))
            {
                using (var writer = new BinaryWriter(stream))
                {
                    foreach (Book book in books)
                    {
                        writer.Write(book.Author);
                        writer.Write(book.Title);
                        writer.Write(book.Pages);
                        writer.Write(book.Year);
                    }
                }
            }
        }
    }
}
