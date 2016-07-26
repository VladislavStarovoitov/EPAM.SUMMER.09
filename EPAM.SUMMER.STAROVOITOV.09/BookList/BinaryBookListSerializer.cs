using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BookList
{
    class BinaryBookListSerializer : IBookListStorage
    {
        public BinaryBookListSerializer(string fileName)
        {
            if (fileName != string.Empty)
                FileName = fileName;
            throw new ArgumentException();
        }

        public string FileName { get; }

        public List<Book> LoadBooks()
        {
            List<Book> result;
            BinaryFormatter formatter = new BinaryFormatter();
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
            BinaryFormatter formatter = new BinaryFormatter();

            using (var fileStream = File.OpenWrite(FileName))
            {
                formatter.Serialize(fileStream, bookList);
            }
        }
    }
}
