using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace BookLibrary
{
    class BookLibrary
    {
        private static readonly string inputFileName = "input.txt";

        private static readonly string outputFileName = "output.txt";
        
        static string[] TakeBookInfoToStringArray(string line)
        {
            return line
                    .Split(' ')
                    .Where(p => !string.IsNullOrWhiteSpace(p))
                    .ToArray();
        }

        static void CleanOutputFile()
        {
            using (StreamWriter writer = new StreamWriter(outputFileName, false))
            {
                writer.Write(String.Empty);
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(inputFileName);

            int n = int.Parse(lines[0]);

            Library library = new Library();

            for (int i = 1; i < n + 1; i++)
            {
                library.AddBook(TakeBookInfoToStringArray(lines[i]));
            }

            CleanOutputFile();

            library.PrintInfo(outputFileName);
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

        public void PrintInfo(string file)
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

            using (StreamWriter writer = new StreamWriter(file, true))
            {
                foreach (KeyValuePair<string, double> peir in sorted)
                {
                    writer.WriteLine($"{peir.Key} -> {peir.Value:0.00}");
                }
                writer.WriteLine();
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
