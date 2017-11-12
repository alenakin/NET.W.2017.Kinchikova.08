using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksConsoleUI
{
    class FilePathProvider
    {
        public static string GetPath()
        {
            string path = String.Empty;
            try
            {
                path = System.Configuration.ConfigurationManager.AppSettings["filepath"];
            }
            catch(Exception)
            {
                path = "books.dat";
            }
            return path;
        }
    }
}
