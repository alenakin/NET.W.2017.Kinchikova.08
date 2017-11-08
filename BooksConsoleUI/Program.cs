using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;
using Books.Predicates;
using Books.Comporators;

namespace BooksConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Elena\Documents\Visual Studio 2017\Projects\NET.W.2017.Kinchikova.08\books.dat";
            BinaryBookListStorage st = new BinaryBookListStorage(path);
            var books = CreateBooks();

            var service = new BookListService(books);
            service.LoadBooks(st);
            service.AddBook(new Book()
            {
                ISBN = "num",
                Author = "Author",
                Name = "Name",
                PublishingHouse = "Publ",
                Year = 1900,
                NumberOfPages = 200,
                Price = 25.3m
            });
            foreach (var b in service.Books)
                Console.WriteLine(b);
            //service.RemoveBook(
            //    new Book()
            //    {
            //        ISBN = "num",
            //        Author = "Author",
            //        Name = "Name",
            //        PublishingHouse = "Publ",
            //        Year = 1900,
            //        NumberOfPages = 200,
            //        Price = 25.3m
            //    });
            foreach (var b in service.Books)
                Console.WriteLine(b);

            Book book1 = new Book()
            {
                ISBN = "num",
                Author = "Author",
                Name = "Name",
                PublishingHouse = "Publ",
                Year = 1900,
                NumberOfPages = 200,
                Price = 25.3m
            };

            var book2 = new Book()
            {
                ISBN = "num",
                Author = "Author",
                Name = "Name",
                PublishingHouse = "Publ",
                Year = 1900,
                NumberOfPages = 200,
                Price = 25.3m
            };

            var book = service.FindBook(new SameYear(), 1900);
            Console.WriteLine(book);

            service.SortBooksByTag(new OrderByYear());
            foreach (var b in service.Books)
                Console.WriteLine(b);
        }

        static List<Book> CreateBooks()
        {
            var books = new List<Book>();

            for (int i = 0; i < 3; i++)
            {
                string ISBN = i.ToString();
                string author = "a" + i;
                string name = "n" + i;
                string publishingHouse = "p" + i;
                int year = 1900 + i;
                int numberOfPages = 20 + i;
                decimal price = 20.3m + i;

                books.Add(new Book
                {
                    ISBN = ISBN,
                    Author = author,
                    Name = name,
                    PublishingHouse = publishingHouse,
                    Year = year,
                    NumberOfPages = numberOfPages,
                    Price = price
                });
            }
            return books;
        }

        static void ShowBookCollection(List<Book> books)
        {
            foreach (var book in books)
                Console.WriteLine(book);
        }
    }
}
