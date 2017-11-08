using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    /// <summary>
    /// Class for representing a condition by which book can be found
    /// </summary>
    /// <typeparam name="T">Type of parameter which value will be used</typeparam>
    public interface IPredicate<T>
    {
        /// <summary>
        /// Show if book fits the condition
        /// </summary>
        /// <param name="book"></param>
        /// <param name="value"></param>
        /// <returns>true if book fits the condition; otherwise, false</returns>
        bool FitsTheTag(Book book, T value);
    }
}
