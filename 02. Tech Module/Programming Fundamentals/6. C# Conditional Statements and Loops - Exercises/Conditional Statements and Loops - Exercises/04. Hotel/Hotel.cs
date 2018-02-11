using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hotel
{
    class Hotel
    {
        static string month;
        static int nights;

        static double studioPrice;
        static double doublePrice;
        static double suitePrice;

        Hotel(string month, int nights)
        {
            Hotel.month = month;
            Hotel.nights = nights;
            setPrice();
            setDiscount();
        }

        static Dictionary<string, Dictionary<string, int>> roomPrice = new Dictionary<string, Dictionary<string, int>>
        {
            {"May", new Dictionary<string, int> { { "Studio", 50 }, { "Double", 65 }, { "Suite", 75 } } },
            {"October", new Dictionary<string, int> { { "Studio", 50 }, { "Double", 65 }, { "Suite", 75 } } },
            {"June", new Dictionary<string, int> { { "Studio", 60 }, { "Double", 72 }, { "Suite", 82 } } },
            {"September", new Dictionary<string, int> { { "Studio", 60 }, { "Double", 72 }, { "Suite", 82 } } },
            {"July", new Dictionary<string, int> { { "Studio", 68 }, { "Double", 77 }, { "Suite", 89 } } },
            {"August", new Dictionary<string, int> { { "Studio", 68 }, { "Double", 77 }, { "Suite", 89 } } },
            {"December", new Dictionary<string, int> { { "Studio", 68 }, { "Double", 77 }, { "Suite", 89 } } },
        };

        static void setPrice()
        {
            studioPrice = roomPrice[month]["Studio"] * nights;
            doublePrice = roomPrice[month]["Double"] * nights;
            suitePrice = roomPrice[month]["Suite"] * nights;
        }

        static void setDiscount()
        {
            if (nights > 7 && (month == "May" || month == "October"))
            {
                studioPrice -= studioPrice * 0.05;
            }
            else if (nights > 14 && (month == "June" || month == "September"))
            {
                doublePrice -= doublePrice * 0.10;
            }
            else if (nights > 14 && (month == "July" || month == "August" || month == "December"))
            {
                suitePrice -= suitePrice * 0.15;
            }

            if (nights > 7 && (month == "September" || month == "October"))
            {
                studioPrice = (studioPrice / nights) * (nights - 1);
            }
        }

        static void print()
        {
            Console.WriteLine($"Studio: {String.Format("{0:0.00}", studioPrice)} lv.");
            Console.WriteLine($"Double: {String.Format("{0:0.00}", doublePrice)} lv.");
            Console.WriteLine($"Suite: {String.Format("{0:0.00}", suitePrice)} lv.");
        }

        static void Main(string[] args)
        {
            Hotel hotel = new Hotel(Console.ReadLine(), int.Parse(Console.ReadLine()));
            print();
        }
    }
}
