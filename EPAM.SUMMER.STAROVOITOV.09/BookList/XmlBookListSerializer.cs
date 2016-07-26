using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop;
using System.IO;
using System.Xml.Serialization;

namespace BookList
{
    class XmlBookListSerializer : IBookListStorage
    {
        public XmlBookListSerializer(string fileName)
        {
            if (fileName != string.Empty)
                FileName = fileName;
            throw new ArgumentException();
        }

        public string FileName { get; }

        public List<Book> LoadBooks()
        {
            List<Book> result;
            XmlSerializer formatter = new XmlSerializer(typeof(BookListService));
            if (!File.Exists(FileName))
                throw new FileNotFoundException();
            try
            {
                using (var fileStream = File.OpenRead(FileName))
                {
                    result = (List<Book>)formatter.Deserialize(fileStream);
                }
            }
            catch (IOException e)
            {
                throw e;
            }
            return result;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            var bookList = books.ToList<Book>();
            XmlSerializer formatter = new XmlSerializer(typeof(BookListService));

            using (var fileStream = File.OpenWrite(FileName))
            {
                formatter.Serialize(fileStream, bookList);
            }
        }
    }
}
