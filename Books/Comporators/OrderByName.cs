using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Comporators
{
    public class OrderByName : IComparer<Book>
    { 
        public int Compare(Book x, Book y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
