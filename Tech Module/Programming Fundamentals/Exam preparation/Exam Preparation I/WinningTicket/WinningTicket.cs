using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinningTicket
{
    class WinningTicket
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                                      .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(a => a.Trim())
                                      .ToArray();

            List<Ticket> tickets = new List<Ticket>();

            foreach (string ticket in array)
            {
                tickets.Add(new Ticket(ticket));
            }
            tickets.ForEach(x => x.Print());
        }
    }

    class Ticket
    {
        private string ticket;
        private bool isValid;
        private bool isMatch;
        private bool isJackpot;
        private char symbol;
        private int matchLegth;

        public Ticket(string ticket)
        {
            this.ticket = ticket;
            IsValid();
            if (this.isValid)
            {
                IsMatch();
            }
        }

        private void IsValid()
        {
            if (ticket.Length == 20)
            {
                this.isValid = true;
            }
            else
            {
                this.isValid = false;
            }
        }

        private void IsMatch()
        {

            this.isMatch = false;

            string leftPart = this.ticket.Substring(0, this.ticket.Length / 2);
            string rightPart = this.ticket.Substring(this.ticket.Length / 2);

            int index = leftPart.Length / 2;
            char symbol = ' ';

            if (leftPart[index] == leftPart[index - 1])
            {
                symbol = leftPart[index];

                int indexOfSymbol = leftPart.IndexOf(symbol);
                int leftCount = leftPart.Skip(indexOfSymbol).TakeWhile(x => x == symbol).Count();

                indexOfSymbol = rightPart.IndexOf(symbol);
                int rightCount = rightPart.Skip(indexOfSymbol).TakeWhile(x => x == symbol).Count();

                if ((leftCount >= 6 && leftCount <= 10) && (rightCount >= 6 && rightCount <= 10))
                {
                    this.isMatch = true;
                    this.symbol = symbol;
                    if (leftCount <= rightCount)
                    {
                        this.matchLegth = leftCount;
                    }
                    else
                    {
                        this.matchLegth = rightCount;
                    }
                }
            }

            if (!Regex.Match(symbol.ToString(), @"[\^\@\#\$]").Success)
            {
                this.isMatch = false;
            }

        }

        private void IsJackpot()
        {
            if (Regex.Match(this.ticket, @"(^)([\@\#\$\^]{10})(\2)($)").Success)
            {
                this.isJackpot = true;
            }
            else
            {
                this.isJackpot = false;
            }
        }

        public void Print()
        {
            if (!isValid)
            {
                Console.WriteLine("invalid ticket");
                return;
            }

            if (!isMatch)
            {
                Console.WriteLine($"ticket \"{this.ticket}\" - no match");
            }
            else
            {
                if (this.matchLegth == 10)
                {
                    Console.WriteLine($"ticket \"{this.ticket}\" - {this.matchLegth}{this.symbol} Jackpot!");
                }
                else if (this.matchLegth >= 6 && this.matchLegth <= 9)
                {
                    Console.WriteLine($"ticket \"{this.ticket}\" - {this.matchLegth}{this.symbol}");
                }
            }
        }
    }
}

