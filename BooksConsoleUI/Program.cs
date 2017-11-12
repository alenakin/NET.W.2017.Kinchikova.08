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
            string path = FilePathProvider.GetPath();
            BinaryBookListStorage storage = new BinaryBookListStorage(path);
            var books = CreateBooks();

            var service = new BookListService(books);
            Console.WriteLine("Books in book service: ");
            ShowBookCollection(service.Books);
           
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
            Console.WriteLine("After adding book: ");
            ShowBookCollection(service.Books);

            var book = service.FindBook(new SameYear(), 1900);
            Console.WriteLine("Book with year of publising - 1900: ");
            Console.WriteLine(book);

            service.RemoveBook(book);
            Console.WriteLine("After removing book: ");
            ShowBookCollection(service.Books);

            service.SortBooksByTag(new OrderByName());
            Console.WriteLine("Sort books by name: ");
            ShowBookCollection(service.Books);

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
