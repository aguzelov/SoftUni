using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.BoatSimulator
{
    class BoatSimulator
    {
        static void Main(string[] args)
        {
            Boat firstBoat = new Boat(char.Parse(Console.ReadLine()));
            Boat secondBoat = new Boat(char.Parse(Console.ReadLine()));

            char winner = ' ';

            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                if(winner != ' ')
                {
                    continue;
                }

                if (input.Equals("UPGRADE"))
                {
                    firstBoat.Upgrade();
                    secondBoat.Upgrade();
                }
                else
                {
                    if (i % 2 != 0)
                    {
                        firstBoat.Move(input);
                    }
                    else
                    {
                        secondBoat.Move(input);
                    }

                }
                
                if(firstBoat.Moves >= 50)
                {
                    winner = firstBoat.Sign;

                }else if(secondBoat.Moves >= 50)
                {
                    winner = secondBoat.Sign;
                }
            }
            if(winner == ' ')
            {
                Console.WriteLine(firstBoat.Moves > secondBoat.Moves? firstBoat.Sign:secondBoat.Sign);
            }

            Console.WriteLine(winner);
        }
    }

    class Boat
    {
        private char sign;
        private int moves = 0;

        public Boat(char sign)
        {
            this.sign = sign;
        }

        public char Sign { get => sign; set => sign = value; }
        public int Moves { get => moves; }

        public void Move(string moves)
        {
            this.moves += moves.Length;
        }
        public void Upgrade()
        {
            this.sign = (char)(this.sign + 3);
        }
    }
}
