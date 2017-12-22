using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Convert_Speed_Units
{
    class ConvertSpeedUnits
    {
        static void Main(string[] args)
        {
            float distance = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float timeInSec = (hours * 3600) + (minutes * 60) + seconds;

            Console.WriteLine(distance/timeInSec);
            Console.WriteLine((distance/1000.0f)/(timeInSec/3600.0f));
            Console.WriteLine(((distance / 1000.0f) / (timeInSec / 3600.0f))/1.609f);
        }
    }
}
