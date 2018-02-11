using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophonTheGrumpyCat
{
    class TrophonTheGrumpyCat
    {
        private static List<int> ratings = new List<int>();

        private static int entryPointItem;
        private static string typeofItem;
        private static string typeOfPriceRating;

        private static void InitRatings()
        {
            ratings = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        }

        private static bool ValidateItem(int item)
        {
            if (typeofItem == "cheap")
            {
                if (item >= entryPointItem)
                {
                    return false;
                }

                if (typeOfPriceRating == "positive")
                {
                    if (item < 0)
                    {
                        return false;
                    }
                    return true;
                }
                else if (typeOfPriceRating == "negative")
                {
                    if (item > 0)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return true;
                }

            }
            else if (typeofItem == "expensive")
            {
                if (item < entryPointItem)
                {
                    return false;
                }

                if (typeOfPriceRating == "positive")
                {
                    if (item < 0)
                    {
                        return false;
                    }
                    return true;
                }
                else if (typeOfPriceRating == "negative")
                {
                    if (item > 0)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            InitRatings();

            int entryPoint = int.Parse(Console.ReadLine());
            entryPointItem = ratings[entryPoint];

            typeofItem = Console.ReadLine();
            typeOfPriceRating = Console.ReadLine();

            long left = 0;

            for (int i = entryPoint - 1; i >= 0; i--)
            {
                if (ValidateItem(ratings[i]))
                {
                    left += ratings[i];
                }
            }

            long right = 0;
            for (int i = entryPoint + 1; i < ratings.Count; i++)
            {
                if (ValidateItem(ratings[i]))
                {
                    right += ratings[i];
                }
            }

            Console.WriteLine(left >= right ? $"Left - {left}" : $"Right - {right}");

        }
    }
}
