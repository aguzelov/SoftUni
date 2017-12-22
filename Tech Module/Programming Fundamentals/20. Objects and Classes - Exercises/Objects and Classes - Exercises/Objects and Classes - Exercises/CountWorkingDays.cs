using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountWorkingDays
{
    class CountWorkingDays
    {
        private static DateTime startDate;
        private static DateTime endDate;

        private static List<DateTime> bulgariaHolidays = new List<DateTime>()
        {
            new DateTime(1, 1, 1),
            new DateTime(1, 3, 3),
            new DateTime(1, 5, 1),
            new DateTime(1, 5, 6),
            new DateTime(1, 5, 24),
            new DateTime(1, 9, 6),
            new DateTime(1, 9, 22),
            new DateTime(1, 11, 1),
            new DateTime(1, 12, 24),
            new DateTime(1, 12, 25),
            new DateTime(1, 12, 26)
        };

        public CountWorkingDays(string startDate, string endDate)
        {
            CountWorkingDays.startDate = DateTime.ParseExact(startDate, "d-M-yyyy", CultureInfo.InvariantCulture);
            CountWorkingDays.endDate = DateTime.ParseExact(endDate, "d-M-yyyy", CultureInfo.InvariantCulture);

            CountWordDay();
        }

        private static void CountWordDay()
        {
            int counter = 0;

            for (DateTime start = startDate; start <= endDate; start = start.AddDays(1))
            {
                if (!IsHoliday(start))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }

        private static bool IsHoliday(DateTime value, IEnumerable<DateTime> holidays = null)
        {
            if (holidays == null)
            {
                holidays = bulgariaHolidays;
            }

            return (value.DayOfWeek == DayOfWeek.Sunday) ||
                    (value.DayOfWeek == DayOfWeek.Saturday) ||
                    holidays.Any(holiday => holiday.Day == value.Day &&
                                            holiday.Month == value.Month);
        }

        static void Main(string[] args)
        {
            new CountWorkingDays(Console.ReadLine(),
                                 Console.ReadLine());

        }
    }

}
