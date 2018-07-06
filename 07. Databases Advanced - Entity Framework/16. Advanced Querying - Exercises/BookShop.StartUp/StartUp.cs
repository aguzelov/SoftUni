namespace BookShop
{
    using BookShop.Data;
    using BookShop.Models;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static object StreamBuilder { get; private set; }

        public static void Main()
        {
            using (var context = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(context);

                //Console.WriteLine(GetBooksByAgeRestriction(context)); - 1.Age Restriction
                //Console.WriteLine(GetGoldenBooks(context)); -2.Golden Books
                //Console.WriteLine(GetBooksByPrice(context)); -3.Books by Price
                //Console.WriteLine(GetBooksNotRealeasedIn(context)); -4.Not Released In
                //Console.WriteLine(GetBooksByCategory(context)); -5.Book Titles by Category
                //Console.WriteLine(GetBooksReleasedBefore(context)); -6.Released Before Date
                //Console.WriteLine(GetAuthorNamesEndingIn(context)); -7.Author Search
                //Console.WriteLine(GetBookTitlesContaining(context)); -8.Book Search
                //Console.WriteLine(GetBooksByAuthor(context)); -9.Book Search by Author
                //Console.WriteLine(CountBooks(context)); -10.Count Books
                //Console.WriteLine(CountCopiesByAuthor(context)); -11.Total Book Copies
                //Console.WriteLine(GetTotalProfitByCategory(context)); -12.Profit by Category
                //Console.WriteLine(GetMostRecentBooks(context)); -13.Most Recent Books
                //Console.WriteLine(IncreasePrices(context)); -14.Increase Prices
                //Console.WriteLine(RemoveBooks(context)); -15.Remove Books
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            int lessThanCopies = 4200;

            var bookLessThan4200Copies = context.Books
                .Where(b => b.Copies < lessThanCopies)
                .ToArray();

            var removedBook = bookLessThan4200Copies.Count();

            context.Books.RemoveRange(bookLessThan4200Copies);
            context.SaveChanges();
            return removedBook;
        }

        public static int IncreasePrices(BookShopContext context)
        {
            var bookBefore2010 = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            bookBefore2010.ForEach(b => b.Price += 5);

            return context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var booksByCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .Select(b => new
                        {
                            Title = b.Book.Title,
                            Date = b.Book.ReleaseDate.Value,
                            Copies = b.Book.Copies
                        })
                        .OrderByDescending(b => b.Date)
                        .Take(3)
                        .ToArray()
                })
                .ToArray()
                .OrderBy(c => c.Name);

            StringBuilder sb = new StringBuilder();
            foreach (var categoryBooks in booksByCategory)
            {
                sb.AppendLine($"--{categoryBooks.Name}");
                foreach (var book in categoryBooks.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Date.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var totalProfitByCategory = context.Categories
               .Select(c => new
               {
                   c.Name,
                   TotalProfit = c.CategoryBooks
                        .Select(cb => cb.Book.Price * cb.Book.Copies)
                        .Sum()
               })
               .OrderByDescending(t => t.TotalProfit)
               .ThenBy(t => t.Name)
               .Select(t => $"{t.Name} ${t.TotalProfit:F2}")
               .ToArray();

            return string.Join($"{Environment.NewLine}", totalProfitByCategory);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsByTotalCopies = context.Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Copies)
                .ToArray();

            return string.Join($"{Environment.NewLine}", authorsByTotalCopies.Select(a => $"{a.Name} - {a.Copies}"));
        }

        public static int CountBooks(BookShopContext context, int? lengthCheck = null)
        {
            if (lengthCheck == null) lengthCheck = int.Parse(Console.ReadLine());

            var booksWithTitleLongerThan = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksWithTitleLongerThan;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input = null)
        {
            if (input == null) input = Console.ReadLine().ToLower();

            var booksTitleAndAuthor = context.Books
                .Where(b => b.Author.LastName.StartsWith(input, StringComparison.OrdinalIgnoreCase))
                .Select(b => new
                {
                    Result = $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})",
                    Id = b.BookId
                })
                .OrderBy(b => b.Id)
                .ToArray();

            return string.Join($"{Environment.NewLine}", booksTitleAndAuthor.Select(b => b.Result));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input = null)
        {
            if (input == null) input = Console.ReadLine().ToLower();

            var booksTitles = context.Books
                .Where(b => b.Title.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0)
                .Select(b => b.Title)
                .ToArray()
                .OrderBy(b => b);

            return string.Join($"{Environment.NewLine}", booksTitles);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input = null)
        {
            if (input == null) input = Console.ReadLine();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray()
                .OrderBy(a => a);

            return string.Join($"{Environment.NewLine}", authors);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date = null)
        {
            if (date == null) date = Console.ReadLine();
            DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
            .Where(b => b.ReleaseDate.Value < releaseDate)
            .Select(b => new
            {
                Result = $"{b.Title} - {b.EditionType} - ${b.Price:F2}",
                ReleaseDate = b.ReleaseDate.Value
            })
            .ToList()
            .OrderByDescending(b => b.ReleaseDate);

            return string.Join($"{Environment.NewLine}", books.Select(b => b.Result));
        }

        public static string GetBooksByCategory(BookShopContext context, string input = null)
        {
            if (input == null)
            {
                input = Console.ReadLine();
            }
            var listOfCategory = input.Split().ToList();

            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    CategoryName = b.BookCategories
                        .Select(bc => bc.Category.Name)
                        .SingleOrDefault()
                })

                .Where(b => listOfCategory.Any(lc => lc.ToLower() == b.CategoryName.ToLower()))
                .ToList()
                .OrderBy(b => b.Title);

            return string.Join($"{Environment.NewLine}", books.Select(b => b.Title));
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int? year = null)
        {
            if (year == null)
            {
                year = int.Parse(Console.ReadLine());
            }

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new { b.Title, b.BookId })
                .ToList()
                .OrderBy(b => b.BookId);

            return string.Join($"{Environment.NewLine}", books.Select(b => b.Title));
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksTitleAndPrice = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price,
                    Result = $"{b.Title} - ${b.Price:F2}"
                })
                .ToArray()
                .OrderByDescending(b => b.Price);

            return string.Join($"{Environment.NewLine}", booksTitleAndPrice.Select(b => b.Result));
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var booksTitleGoldenEdition = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .ToList()
                .OrderBy(b => b.BookId);

            return string.Join($"{Environment.NewLine}", booksTitleGoldenEdition.Select(b => b.Title));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command = null)
        {
            if (command == null)
            {
                command = Console.ReadLine();
            }

            AgeRestriction ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .ToList()
                .OrderBy(b => b);

            return string.Join($"{Environment.NewLine}", books);
        }
    }
}