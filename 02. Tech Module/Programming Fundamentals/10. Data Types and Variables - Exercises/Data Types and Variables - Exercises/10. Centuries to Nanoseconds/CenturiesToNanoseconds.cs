using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Centuries_to_Nanoseconds
{
    class CenturiesToNanoseconds
    {
        sbyte Centuries;
        int Years;
        int Days;
        int Hours;
        long Minutes;
        long Seconds;
        ulong Milliseconds;
        ulong Microseconds;
        decimal Nanoseconds;

        public CenturiesToNanoseconds(sbyte centuries)
        {
            Centuries = centuries;
            Years = Centuries * 100;
            Days = (int)Math.Floor(Years * 365.2422);
            Hours = Days * 24;
            Minutes = Hours * 60;
            Seconds = Minutes * 60;
            Milliseconds = (ulong)Seconds * 1000;
            Microseconds = Milliseconds * 1000;
            Nanoseconds = (decimal)Microseconds * 1000;
        }

        public void Print()
        {
            Console.WriteLine($"{Centuries} centuries = " +
                              $"{Years} years = " +
                              $"{Days} days = " +
                              $"{Hours} hours = " +
                              $"{Minutes} minutes = " +
                              $"{Seconds} seconds = " +
                              $"{Milliseconds} milliseconds = " +
                              $"{Microseconds} microseconds = " +
                              $"{Nanoseconds} nanoseconds");
        }

        static void Main(string[] args)
        {
            CenturiesToNanoseconds centuries = new CenturiesToNanoseconds(sbyte.Parse(Console.ReadLine()));
            centuries.Print();
           
        }
    }
}
