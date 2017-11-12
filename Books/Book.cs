using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    /// <summary>
    /// Class for storing information about book
    /// </summary>
    public class Book : IEquatable<Book>, IComparable<Book>, IComparable, IFormattable
    {
        #region Fields 
        private string isbn;
        private string author;
        private string name;
        private string publishingHouse;
        private int year;
        private int numberOfPages;
        private decimal price;
        #endregion

        #region Properties
        public string ISBN
        {
            get => isbn;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                   $"{nameof(value)} must have some value.");
                }

                isbn = value;
            }
        }

        public string Author
        {
            get => author;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                   $"{nameof(value)} must have some value.");
                }

                author = value;
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                   $"{nameof(value)} must have some value.");
                }

                name = value;
            }
        }

        public string PublishingHouse
        {
            get => publishingHouse;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                   $"{nameof(value)} must have some value.");
                }

                publishingHouse = value;
            }
        }

        public int Year
        {
            get => year;
            set
            {
                if (value < 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentOutOfRangeException(
                   $"{nameof(value)} must be between 0 and {DateTime.Now.Year}.");
                }

                year = value;
            }
        }

        public int NumberOfPages
        {
            get => year;
            set
            {
                if (value < 0)
                { 
                    throw new ArgumentOutOfRangeException(
                   $"{nameof(value)} must be greater than zero.");
                }

                if (value > 3000)
                {
                    throw new ArgumentOutOfRangeException(
                   $"{nameof(value)} too large to be the number of pages in book.");
                }

                numberOfPages = value;
            }
        }

        public decimal Price
        {
            get => year;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                   $"{nameof(value)} must be greater than zero.");
                }

                price = value;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Compares the current instance with another object of type Book
        /// </summary>
        /// <param name="other">Book to compare with</param>
        /// <returns>An integer that indicates whether the current 
        /// instance precedes, follows, or occurs in the same position in the sort order as the other object.</returns>
        public int CompareTo(Book other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            return Author.CompareTo(other.Author);
        }

        /// <summary>
        /// Compares the current instance with another object
        /// </summary>
        /// <param name="other">Object to compare with</param>
        /// <returns>An integer that indicates whether the current 
        /// instance precedes, follows, or occurs in the same position in the sort order as the other object.</returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            if (!(obj is Book))
            {
                throw new ArgumentException();
            }

            return CompareTo((Book)obj);
        }

        /// <summary>
        /// Determines whether the specified object of type Book is equal to the current object.
        /// </summary>
        /// <param name="book">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public bool Equals(Book book)
        {
            if (book == null)
            {
                return false;
            }

            if (this == book)
            {
                return true;
            }

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
            {
                return false;
            }

            if (this == value)
            {
                return true;
            }

            if (!(value is Book))
            {
                return false;
            }

            Book b = (Book)value;
            return this.Equals(b);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = (37 * result) + ISBN.GetHashCode();
            result = (37 * result) + Author.GetHashCode();
            result = (37 * result) + Name.GetHashCode();
            result = (37 * result) + PublishingHouse.GetHashCode();
            result = (37 * result) + Year;
            result = (37 * result) + NumberOfPages;
            return result;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>String representation of current object.</returns>
        public override string ToString()
        {
            return ToString("F");
        }

        /// <summary>
        /// Returns a string that represents the current object using specified format.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            return ToString(format, null);
        }

        /// <summary>
        /// Returns a string that represents the current object using specified format and specified format provider.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "F";
            }

            if (provider == null)
            {
                provider = CultureInfo.CreateSpecificCulture("en-US");
            }

            switch (format.ToUpperInvariant())
            {
                case "F":
                    return $"ISBN: {ISBN}, {Author}, {Name}, {PublishingHouse}, {Year}, P.{numberOfPages}, {Price.ToString("C", provider)}";
                case "AN":
                    return $"{Author}, {Name}";
                case "ANY":
                    return $"{Author}, {Name}, {Year}";
                case "FWP":
                    return $"ISBN: {ISBN}, {Author}, {Name}, {PublishingHouse}, {Year}, P.{numberOfPages}";
                default:
                    throw new FormatException(string.Format("The {0} format string is not supported.", format));
            }
        }
        #endregion
    }
}
