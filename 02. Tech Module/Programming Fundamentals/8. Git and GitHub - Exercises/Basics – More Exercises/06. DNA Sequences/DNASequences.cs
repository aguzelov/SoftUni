using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.DNA_Sequences
{
    class DNASequences
    {
        static Dictionary<char, int> NucleotideValue = new Dictionary<char, int>
        {
            {'A', 1 },
            {'C', 2 },
            {'G', 3 },
            {'T', 4 }
        };
        static char[] possibleNucleicAcid = { 'A', 'C', 'G', 'T' };
        static void Main(string[] args)
        {
            int matchSum = int.Parse(Console.ReadLine());

            foreach(char first in possibleNucleicAcid)
            {
                foreach (char second in possibleNucleicAcid)
                {
                    foreach (char third in possibleNucleicAcid)
                    {
                        int numericValue = NucleotideValue[first] + NucleotideValue[second] + NucleotideValue[third];
                        if(numericValue >= matchSum)
                        {
                            Console.Write($"O{first}{second}{third}O");
                        }
                        else
                        {
                            Console.Write($"X{first}{second}{third}X");
                        }

                        if(third == 'T')
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
            }

        }
    }
}
