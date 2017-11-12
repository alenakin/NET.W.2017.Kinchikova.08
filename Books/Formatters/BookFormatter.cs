using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formatters
{
    public class BookFormatter : ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider provider)
        {
            if (!(arg is Book))
            {
                throw new ArgumentException("arg must be of type Book");
            }

            Book book = (Book)arg;

            if (provider == null)
            {
                provider = CultureInfo.CreateSpecificCulture("en-US");
            }

            switch (format.ToUpperInvariant())
            {
                case "IAN":
                    return $"ISBN: {book.ISBN}, {book.Author}, {book.Name}";
                case "ANP":
                    return $"{book.Author}, {book.Name}, {book.Price.ToString("C", provider)}";
                default:
                    throw new FormatException(string.Format("The {0} format string is not supported.", format));
            }
        }
    }
}
