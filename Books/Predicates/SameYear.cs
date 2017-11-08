using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Predicates
{
    /// <summary>
    /// Predicate for equal years
    /// </summary>
    public class SameYear : IPredicate<int>
    {
        /// <summary>
        /// Show if book's year is equal to value
        /// </summary>
        /// <param name="book"></param>
        /// <param name="value"></param>
        /// <returns>true if book's year is equal to value; otherwise, false</returns>
        public bool FitsTheTag(Book book, int value)
        {
            return book.Year.Equals(value);
        }
    }
}
