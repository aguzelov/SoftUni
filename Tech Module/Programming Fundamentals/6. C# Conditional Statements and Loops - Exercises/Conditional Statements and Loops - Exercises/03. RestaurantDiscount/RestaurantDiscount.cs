using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RestaurantDiscount
{
    class RestaurantDiscount
    {
        static double price;
        static int groupSize;
        static string package;
        static string hallType;

        RestaurantDiscount(int group, string package)
        {
            RestaurantDiscount.groupSize = group;
            RestaurantDiscount.package = package;
        }

        static void setHall()
        {
            if(groupSize <= 50)
            {
                hallType = "Small Hall";
                price = 2500;
            }else if(groupSize > 50 && groupSize <= 100)
            {
                hallType = "Terrace";
                price = 5000;
            }
            else if(groupSize > 100 && groupSize <= 120)
            {
                hallType = "Great Hall";
                price = 7500;
            }
        }

        static void setPackageAndDiscount()
        {
            if(package == "Normal")
            {
                price += 500;
                price -= price * 0.05;
            }else if(package == "Gold")
            {
                price += 750;
                price -= price * 0.10;
            }
            else if(package == "Platinum")
            {
                price += 1000;
                price -= price * 0.15;
            }
        }

        static void printPricePerPerson()
        {
            if(groupSize > 120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
            else
            {
                Console.WriteLine($"We can offer you the {hallType}");
                Console.WriteLine($"The price per person is {String.Format("{0:0.00}", price/groupSize)}$");
            }
        }

        static void Main(string[] args)
        {
            RestaurantDiscount restaurant = new RestaurantDiscount(int.Parse(Console.ReadLine()), Console.ReadLine());

            setHall();
            setPackageAndDiscount();
            printPricePerPerson();
        }
    }
}
