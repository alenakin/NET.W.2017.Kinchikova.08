using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Predicates
{
    /// <summary>
    /// Predicate for equal names
    /// </summary>
    public class SameNames : IPredicate<string>
    {
        /// <summary>
        /// Show if book name is equal to value
        /// </summary>
        /// <param name="book"></param>
        /// <param name="value"></param>
        /// <returns>true if book name is equal to value; otherwise, false</returns>
        public bool FitsTheTag(Book book, string value)
        {
            return book.Name.Equals(value);
        }
    }
}
