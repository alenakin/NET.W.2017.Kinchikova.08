using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksConsoleUI
{
    internal class FilePathProvider
    {
        public static string GetPath()
        {
            string path = string.Empty;
            try
            {
                path = System.Configuration.ConfigurationManager.AppSettings["filepath"];
            }
            catch (Exception)
            {
                path = "books.dat";
            }

            return path;
        }
    }
}
