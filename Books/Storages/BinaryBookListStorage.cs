using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    /// <summary>
    /// Storage for book collections which use binary files
    /// </summary>
    public class BinaryBookListStorage : IBookListStorage
    {
        private string filePath;

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filePath">Path to the binary file</param>
        public BinaryBookListStorage(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Load book collection from binary file
        /// </summary>
        /// <returns>Book collection</returns>
        public List<Book> Load()
        {
            var books = new List<Book>() { };
            var file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);

            using (var reader = new BinaryReader(file))
                while(reader.PeekChar() != -1)
                    books.Add(ReadBookFromFile(reader));

            return books;
        }

        /// <summary>
        /// Save book collection to the binary file
        /// </summary>
        /// <param name="books"></param>
        public void Save(IEnumerable<Book> books)
        {
            var file = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            using (var writer = new BinaryWriter(file))
            {
                Console.WriteLine(file.CanRead);
                foreach (Book book in books)
                    WriteBookToFile(writer, book);
            }
        }

        #region Private methods
        private Book ReadBookFromFile(BinaryReader reader)
        {
            string ISBN = reader.ReadString();
            string author = reader.ReadString();
            string name = reader.ReadString();
            string publishingHouse = reader.ReadString();
            int year = reader.ReadInt32();
            int numberOfPages = reader.ReadInt32();
            decimal price = reader.ReadDecimal();

            return new Book
            {
                ISBN = ISBN,
                Author = author,
                Name = name,
                PublishingHouse = publishingHouse,
                Year = year,
                NumberOfPages = numberOfPages,
                Price = price
            };
        }

        private void WriteBookToFile(BinaryWriter writer, Book book)
        {
            writer.Write(book.ISBN);
            writer.Write(book.Author);
            writer.Write(book.Name);
            writer.Write(book.PublishingHouse);
            writer.Write(book.Year);
            writer.Write(book.NumberOfPages);
            writer.Write(book.Price);
        }
        #endregion

        #endregion
    }
}
