using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    /// <summary>
    /// Class for storing information about book
    /// </summary>
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        #region Fields 
        private int year;
        private int numberOfPages;
        private decimal price;
        #endregion

        #region Properties
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string PublishingHouse { get; set; }
        public int Year
        {
            get => year;
            set
            {
                if (value < 0 || value > DateTime.Now.Year)
                    throw new ArgumentOutOfRangeException(
                   $"{nameof(value)} must be between 0 and {DateTime.Now.Year}.");

                year = value;
            }
        }
        public int NumberOfPages
        {
            get => year;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                   $"{nameof(value)} must be greater than zero.");

                numberOfPages = value;
            }
        }
        public decimal Price
        {
            get => year;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                   $"{nameof(value)} must be greater than zero.");

                price = value;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Compares the current instance with another object of type Book
        /// </summary>
        /// <param name="other"></param>
        /// <returns>An integer that indicates whether the current 
        /// instance precedes, follows, or occurs in the same position in the sort order as the other object.</returns>
        public int CompareTo(Book other)
        {
            if (other == null)
                throw new ArgumentNullException();

            return Author.CompareTo(other.Author);
        }

        /// <summary>
        /// Determines whether the specified object of type Book is equal to the current object.
        /// </summary>
        /// <param name="book">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public bool Equals(Book book)
        {
            if (book == null)
                return false;
            if (this == book)
                return true;

            return ISBN.Equals(book.ISBN) && Author.Equals(book.Author) && Name.Equals(book.Name)
                && PublishingHouse.Equals(book.PublishingHouse) && Year == book.Year
                && NumberOfPages == book.NumberOfPages && Price == book.Price;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="value">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object value)
        {
            if (value == null)
                return false;
            if (this == value)
                return true;
            if (!(value is Book))
                return false;

            Book b = (Book)value;
            return Equals(b);
        }

        /// <summary>
        /// Hash function
        /// </summary>
        /// <returns>Hash of current object</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 37 * result + ISBN.GetHashCode();
            result = 37 * result + Author.GetHashCode();
            result = 37 * result + Name.GetHashCode();
            result = 37 * result + PublishingHouse.GetHashCode();
            result = 37 * result + Year;
            result = 37 * result + NumberOfPages;
            return result;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";
            result += "ISBN: " + ISBN;
            result += ", author: " + Author;
            result += ", name: " + Name;
            result += ", publishing house: " + PublishingHouse;
            result += ", year: " + Year;
            result += ", number of pages: " + NumberOfPages;
            result += ", price: " + Price;
            return result;
        }
        #endregion
    }


}
