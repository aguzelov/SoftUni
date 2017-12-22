using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthPrinter
{
    class MonthPrinter
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if(number < 1 || number > 12)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                string fullMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(number);
                //string fullMonthName = new DateTime(2017, number, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("us"));
                Console.WriteLine(fullMonthName);
            }
            
        }
    }
}
