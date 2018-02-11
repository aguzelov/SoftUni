using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOfCards
{
    class HandsOfCards
    {
        static HashSet<Player> players = new HashSet<Player>();

        static void PrintScores()
        {
            foreach (Player player in players)
            {
                player.PrintCardValue();
            }
        }

        static bool TakeInput()
        {
            string[] input = Console.ReadLine()
                                .Split(':')
                                .ToArray();

            if (input[0] == "JOKER")
            {
                PrintScores();
                return false;
            }

            string name = input[0];

            List<string> cards = input[1]
                                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Where(p => !string.IsNullOrWhiteSpace(p))
                                .ToList();

            bool isInHashSet = false;
            foreach (Player p in players)
            {
                if (p.Equal(new Player(name)))
                {
                    isInHashSet = true;
                }
            }

            if (isInHashSet)
            {
                Player currendPlayer = players.Where(p => p.Name == name).FirstOrDefault();
                currendPlayer.DrawCard(cards);
            }
            else
            {
                players.Add(new Player(name));
                Player currendPlayer = players.Where(p => p.Name == name).FirstOrDefault();
                currendPlayer.DrawCard(cards);
            }

            return true;
        }

        static void Main(string[] args)
        {
            while (TakeInput())
            {

            }
        }
    }
    class Player
    {
        private string name;
        private int cardValue;

        private HashSet<string> cards = new HashSet<string>();

        private Dictionary<string, int> cardPowers = new Dictionary<string, int> {
            {"S", 4 },
            {"H", 3 },
            {"D", 2 },
            {"C", 1 },
            {"2", 2 },
            {"3", 3 },
            {"4", 4 },
            {"5", 5 },
            {"6", 6 },
            {"7", 7 },
            {"8", 8 },
            {"9", 9 },
            {"10",10 },
            {"J", 11 },
            {"Q", 12 },
            {"K", 13 },
            {"A", 14 },
        };

        public Player(string name)
        {
            this.name = name;
            this.cardValue = 0;
        }

        public string Name { get => name; set => name = value; }
        public int CardValue { get => cardValue; set => cardValue = value; }

        public void DrawCard(List<string> cards)
        {
            foreach (string card in cards)
            {
                this.cards.Add(card);
            }
        }

        public void CalculateValue()
        {
            foreach (string card in cards)
            {
                char type = card[card.Length - 1];
                string power = card.Remove(card.Length - 1);

                this.cardValue += this.cardPowers[type.ToString()] * this.cardPowers[power];
            }
        }

        public void PrintCardValue()
        {
            CalculateValue();
            Console.WriteLine($"{this.name}: {this.cardValue}");
        }

        public bool Equal(Player other)
        {
            if (this.name == other.Name)
            {
                return true;
            }
            return false;
        }

    }
}
