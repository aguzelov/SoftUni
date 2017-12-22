using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BPM_Counter
{
    class BPMCounter
    {
        static string LengthCalc(int bpm, int nob)
        {
            double time = nob / ((double)bpm / 60);
            
            return $"{String.Format("{0:0}", (int)time / 60)}m {String.Format("{0:0}", Math.Floor(time) % 60)}s";
        }
        static void Main(string[] args)
        {
            int bpm = int.Parse(Console.ReadLine());
            int nob = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"{Math.Round(((double)nob/4),1)} bars - {LengthCalc(bpm,nob)}");
        }
    }
}
