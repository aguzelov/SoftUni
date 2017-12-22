using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Calories_Counter
{
    class CaloriesCounter
    {
        static int totalCalories;

        static Dictionary<String, int> calories = new Dictionary<string, int>
        {
            {"cheese", 500 },
            {"tomato sauce", 150 },
            {"salami", 600 },
            {"pepper", 50 }
        };

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string ingredient;

            for(int i = 0; i < n; i++)
            {
                ingredient = Console.ReadLine();
                int value = 0;
                if (calories.TryGetValue(ingredient.ToLower(),out value))
                {
                    totalCalories += value;
                }
            }
            Console.WriteLine($"Total calories: {totalCalories}");
        }
    }
}
