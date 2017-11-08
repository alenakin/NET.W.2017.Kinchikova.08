using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Comporators
{
    public class OrderByYear : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }
}
