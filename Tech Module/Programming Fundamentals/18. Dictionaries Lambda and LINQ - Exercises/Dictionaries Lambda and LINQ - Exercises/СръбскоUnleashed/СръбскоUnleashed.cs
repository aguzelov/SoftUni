using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace СръбскоUnleashed
{
    class СръбскоUnleashed
    {
        static Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>> { };

        static bool TakeInput()
        {
            string input = Console.ReadLine();

            if(input == "End")
            {
                ReportData();
                return false;
            }

            if (!ExtractInfo(input, out string name, out string place, out long money))
            {
                return true;
            }

            if (data.ContainsKey(place))
            {
                if (data[place].ContainsKey(name))
                {
                    data[place][name] += money;
                }
                else
                {
                    data[place].Add(name, money);
                }
            }
            else
            {
                data.Add(place, new Dictionary<string, long> { });
                data[place].Add(name, money);
            }

            return true;
        }

        static bool ExtractInfo(string text, out string name, out string place, out long money)
        {
            name = "";
            place = "";
            money = 0;

            //"singer @venue ticketsPrice ticketsCount"
            int atIndex = text.IndexOf("@");

            if (atIndex < 0)
            {
                return false;
            }

            if (text[atIndex - 1] != ' ')
            {
                return false;
            }

            name = text.Substring(0, atIndex - 1);

            int priceAndTicketIndex = text.IndexOfAny("1234567890".ToCharArray());

            if (text[priceAndTicketIndex - 1] != ' ')
            {
                return false;
            }

            string[] priceAndTicket = text.Substring(priceAndTicketIndex, text.Length - priceAndTicketIndex).Split(' ').ToArray();

            long price = long.Parse(priceAndTicket[0]);

            if (priceAndTicket.Length < 2)
            {
                return false;
            }

            long ticket = long.Parse(priceAndTicket[1]);

            money = price * ticket;

            atIndex++;
            priceAndTicketIndex--;
            place = text.Substring(atIndex, priceAndTicketIndex - atIndex);

            return true;
        }

        static void ReportData()
        {
            foreach(var place in data)
            {
                Console.WriteLine(place.Key);

                var sorted = data[place.Key].OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);

                foreach (var e in sorted)
                {
                    Console.WriteLine($"#  {e.Key} -> {e.Value}");
                }
            }
        }

        static void Main(string[] args)
        {
            while (TakeInput())
            {
            }
        }
    }
}
