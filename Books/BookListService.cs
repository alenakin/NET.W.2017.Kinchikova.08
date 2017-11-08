using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    /// <summary>
    /// Class for working with collection of books
    /// </summary>
    public class BookListService
    {
        public List<Book> Books { get; private set; }  = new List<Book>() { };

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="books"></param>
        public BookListService(List<Book> books)
        {
            Books = new List<Book>(books);
        }

        /// <summary>
        /// Load collection of books from specified storage
        /// </summary>
        /// <param name="bookListStorage"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void LoadBooks(IBookListStorage bookListStorage)
        {
            if (bookListStorage == null)
                throw new ArgumentNullException();

            Books = bookListStorage.Load();
        }

        /// <summary>
        /// Save collection of books in specified storage
        /// </summary>
        /// <param name="bookListStorage"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SaveBooks(IBookListStorage bookListStorage)
        {
            if (bookListStorage == null)
                throw new ArgumentNullException();

            bookListStorage.Save(Books);
        }

        /// <summary>
        /// Add book to collection
        /// </summary>
        /// <param name="book"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException();
            if (Books.Contains(book))
                throw new Exception("This book is already in the collection");

            Books.Add(book);
        }

        /// <summary>
        /// Add range of book to collection
        /// </summary>
        /// <param name="books"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddBookRange(List<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException();
            foreach (Book b in books)
                if (!Books.Contains(b))
                    Books.Add(b);
        }

        /// <summary>
        /// Remove specified book from collection
        /// </summary>
        /// <param name="book"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveBook(Book book)
        {
            if (!Books.Contains(book))
                throw new ArgumentException("There is no such book in the collection");

            Books.Remove(book);
        }

        /// <summary>
        /// Finds first book with equal value of specified parameter
        /// </summary>
        /// <param name="predicate">Predicate which specifies tag by value of which book will be chosen</param>
        /// <param name="value">Value by which book will be chosen</param>
        /// <returns></returns>
        public Book FindBook<T>(IPredicate<T> predicate, T value)
        {
            if (predicate == null)
                throw new ArgumentNullException();

            foreach (var book in Books)
            {
                if (predicate.FitsTheTag(book, value))
                    return book;
            }
            return null;
        }

        /// <summary>
        /// Sort book collection by specified comparator
        /// </summary>
        /// <param name="comparer"></param>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();

            Books.Sort(comparer);
        }
        #endregion 
    }
}
