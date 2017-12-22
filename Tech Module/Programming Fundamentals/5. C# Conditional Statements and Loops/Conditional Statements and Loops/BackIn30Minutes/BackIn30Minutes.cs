using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackIn30Minutes
{
    class BackIn30Minutes
    {
        int hours;
        int minutes;
        BackIn30Minutes(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
            add30Minutes();
        }
        void add30Minutes()
        {
            if(this.minutes+30 >= 60)
            {
                this.hours++;
                if (this.hours == 24)
                {
                    this.hours = 0;
                }
                this.minutes = this.minutes + 30 - 60;
            }
            else
            {
                this.minutes += 30;
            }
        }
        void printTime()
        {
            Console.WriteLine(this.hours + ":" + String.Format("{0:00}",this.minutes));
        }
        static void Main(string[] args)
        {
            BackIn30Minutes time = new BackIn30Minutes(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            time.printTime();

        }
    }
}
