using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class BookLibrary
    {
        static string[] TakeBookInfoToStringArray()
        {
            return Console.ReadLine()
                          .Split(' ')
                          .Where(p => !string.IsNullOrWhiteSpace(p))
                          .ToArray();
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Library library = new Library();

            for (int i = 0; i < n; i++)
            {
                library.AddBook(TakeBookInfoToStringArray());
            }
            library.PrintInfo();
        }
    }

    class Library
    {
        private string name;
        private List<Book> books;

        public Library()
        {
            this.name = "Library name";
            this.books = new List<Book>();
        }

        public string Name { get => name; set => name = value; }

        public void AddBook(string[] book)
        {
            books.Add(new Book(book[0], book[1], book[2], book[3], book[4], book[5]));
        }

        public void PrintInfo()
        {
            Dictionary<string, double> info = new Dictionary<string, double> { };

            foreach (Book book in books)
            {
                if (info.ContainsKey(book.Author))
                {
                    info[book.Author] += book.Price;
                }
                else
                {
                    info.Add(book.Author, book.Price);
                }
            }

            var sorted = info.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, double> peir in sorted)
            {
                Console.WriteLine($"{peir.Key} -> {string.Format("{0:0.00}", peir.Value)}");
            }
        }

    }
    class Book
    {
        private string title;
        private string author;
        private string publisher;
        private DateTime releaseDate;
        private string isbn;
        private double price;

        public Book(string title, string author, string publisher, string releaseDate, string isbn, string price)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.releaseDate = DateTime.ParseExact(releaseDate, "d.M.yyyy", CultureInfo.InvariantCulture);
            this.isbn = isbn;
            this.price = double.Parse(price);
        }

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public DateTime ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public string ISBN1 { get => isbn; set => isbn = value; }
        public double Price { get => price; set => price = value; }
    }

}
