using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    /// <summary>
    /// Interface for storages for book collections
    /// </summary>
    public interface IBookListStorage
    {
        /// <summary>
        /// Save collection of books in storage
        /// </summary>
        /// <param name="books"></param>
        void Save(List<Book> books);

        /// <summary>
        /// Load collection of books from storage
        /// </summary>
        /// <returns>Collection of books</returns>
        List<Book> Load();
    }
}
